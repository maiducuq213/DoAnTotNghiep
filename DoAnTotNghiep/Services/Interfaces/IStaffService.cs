using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaff();
        Task<Staff?> GetStaffById(int id);
        Task<Staff> AddStaff(StaffDto staffDto);
        Task<Staff?> UpdateStaff(int id, StaffDto staffDto);
        Task<bool> DeleteStaff(int id);
    }
}
