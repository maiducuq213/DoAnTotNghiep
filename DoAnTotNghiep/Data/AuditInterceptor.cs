using DoAnTotNghiep.Models.BaseEntities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace DoAnTotNghiep.Data
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context == null) return result;

            var user = _httpContextAccessor.HttpContext?.User.FindFirst("UserName")?.Value;
            //var userAccount = _hospitalContext.UserAccounts.First(u => u.UserName == user);
            //var staff = _hospitalContext.Staffs.FirstOrDefault(s => s.Id == userAccount.StaffId);
            Console.WriteLine($" AuditInterceptor Running - User: {user}"); // Debug log
            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = user;
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.UpdatedBy = user;
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedBy = user;
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }
            return await base.SavingChangesAsync(eventData, result,cancellationToken);
        }
    }
}
