namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    public class StaffService :IStaffService
    {
        private readonly HospitalContext _context;

        public StaffService(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Staff>> GetAllStaff()
        {
            return await _context.Staffs.ToListAsync();
        }
        public async Task<Staff> GetStaffById(int id)
        {
            return await _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Staff> AddStaff(Staff staff)
        {
             _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }
        public async Task<Staff> UpdateStaff(int id, Staff staff)
        {
            var existingStaff = await _context.Staffs.FindAsync(id);
            if (existingStaff == null)
                return null;
            existingStaff.FullName = staff.FullName;
            existingStaff.DepartmentID = staff.DepartmentID;
            existingStaff.Phone = staff.Phone;
            existingStaff.Email = staff.Email;
            existingStaff.Address = staff.Address;
            existingStaff.HireDate = staff.HireDate;
            existingStaff.Salary = staff.Salary;

            await _context.SaveChangesAsync();
            return existingStaff;

        }
        public async Task<bool> DeleteStaff(int id)
        {
            var existingStaff = await _context.Staffs.FindAsync(id);
            if (existingStaff == null)
                return false;
            _context.Remove(existingStaff);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
