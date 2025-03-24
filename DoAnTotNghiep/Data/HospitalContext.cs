using DoAnTotNghiep.Models;
using DoAnTotNghiep.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace DoAnTotNghiep.Data
{
    public class HospitalContext:DbContext
    {
        private readonly AuditInterceptor _auditInterceptor;


        public HospitalContext(DbContextOptions<HospitalContext> options, AuditInterceptor auditInterceptor) : base(options)
        {
            _auditInterceptor = auditInterceptor;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_auditInterceptor != null)
            {
                optionsBuilder.AddInterceptors(_auditInterceptor);
            }
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<PaymentInvoice> PaymentInvoices { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Patient>()
                .Property(p => p.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<PaymentInvoice>()
                .Property(p => p.PaymentGateway)
                .HasConversion<string>();

            modelBuilder.Entity<Bed>()
                .Property(b => b.Status)
                .HasConversion<string>();
        }
        
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var userId = GetCurrentUserId(); // Lấy ID của người dùng hiện tại

        //    var entries = ChangeTracker.Entries<BaseEntity>();

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.CreatedAt = DateTime.UtcNow;
        //            entry.Entity.CreatedBy = userId;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Entity.UpdatedAt = DateTime.UtcNow;
        //            entry.Entity.UpdatedBy = userId;
        //        }
        //    }

        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //private int? GetCurrentUserId()
        //{
        //    var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    return int.TryParse(userIdString, out var userId) ? userId : null;
        //}
    }
}
