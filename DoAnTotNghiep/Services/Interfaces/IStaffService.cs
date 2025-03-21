using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaff();
        Task<Staff> GetStaffById(int id);
        Task<Staff> AddStaff(Staff staff);
        Task<Staff> UpdateStaff(int id, Staff staff);
        Task<bool> DeleteStaff(int id);
    }
}
