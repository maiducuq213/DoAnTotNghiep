namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    using DoAnTotNghiep.DTOs;
    using Microsoft.AspNetCore.Mvc;

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
        public async Task<Staff?> GetStaffById(int id)
        {
            return await _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Staff> AddStaff([FromBody]StaffDto staffDto)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == staffDto.DepartmentName);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            var addStaff = new Staff
            {
                FullName = staffDto.FullName,
                Address = staffDto.Address,
                Email = staffDto.Email,
                DepartmentID = department.Id,
                HireDate = DateTime.Now,
                Phone = staffDto.Phone,
                Salary = staffDto.Salary,
                IsDeleted = false

            };
            _context.Staffs.Add(addStaff);
            await _context.SaveChangesAsync();
            return addStaff;
        }
        public async Task<Staff?> UpdateStaff(int id, StaffDto staffDto)
        {
            var existingStaff = await _context.Staffs.FindAsync(id);
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == staffDto.DepartmentName);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            if (existingStaff == null)
            {
                return null;
            }
                
            existingStaff.FullName = staffDto.FullName;
            existingStaff.DepartmentID = department.Id;
            existingStaff.Phone = staffDto.Phone;
            existingStaff.Email = staffDto.Email;
            existingStaff.Address = staffDto.Address;
            existingStaff.HireDate = staffDto.HireDate;
            existingStaff.Salary = staffDto.Salary;
            
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
