using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> RegisterAccount(AccountDto accountDto);
        Task<Account?> UpdateAccount(string userName,AccountDto accountDto);
        //Task<bool?> SoftDelete(string userName);
    }
}
