using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> GenerateJwtToken(UserAccount user);
    }
}
