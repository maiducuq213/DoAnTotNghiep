using DoAnTotNghiep.Data;
using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly HospitalContext _hospitalContext;

        public AccountService(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }
        public async Task<Account> RegisterAccount(AccountDto accountDto)
        {
            var newAccount = new Account
            {
                UserName = accountDto.UserName,
                Password = accountDto.Password,
                Role = accountDto.Role,
                IsActive = accountDto.IsActive,
                StaffId = accountDto.StaffId,
                
            };
            await _hospitalContext.UserAccounts.AddAsync(newAccount);
            await _hospitalContext.SaveChangesAsync();
            return newAccount;
        }
        public async Task<Account?> UpdateAccount(string userName,AccountDto accountDto)
        {
            var existingAccount = await _hospitalContext.UserAccounts.FirstOrDefaultAsync(u => u.UserName==userName);
            if (existingAccount == null)
            {
                return null;
            }
            existingAccount.UserName = accountDto.UserName;
            existingAccount.Role = accountDto.Role;
            existingAccount.IsActive = accountDto.IsActive;
            existingAccount.Password = accountDto.Password;
            existingAccount.StaffId = accountDto.StaffId;
            

            await _hospitalContext.SaveChangesAsync();
            return existingAccount;
        }
    }
}
