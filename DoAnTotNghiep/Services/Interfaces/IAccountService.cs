using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserAccount> RegisterAccount(AccountDto accountDto);
        Task<UserAccount?> UpdateAccount(string userName,AccountDto accountDto);
    }
}
