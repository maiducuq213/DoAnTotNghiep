namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    using DoAnTotNghiep.DTOs;

    public class BedService : IBedService
    {
        private readonly HospitalContext _context;

        public BedService(HospitalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bed>> GetAllBeds()
        {
            return await _context.Beds.Include(b => b.Department).ToListAsync();
        }

        public async Task<Bed?> GetBedById(int id)
        {
            return await _context.Beds.Include(b => b.Department)
                                        .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Bed> AddBed(BedDto bedDto)
        {
            var createBed = new Bed
            {
                RoomNumber = bedDto.RoomNumber,
                DepartmentID = bedDto.DepartmentID,
                Status = bedDto.Status,
                PatientID = bedDto.PatientID
            };
            _context.Beds.Add(createBed);
            await _context.SaveChangesAsync();
            return createBed;
        }

        public async Task<Bed?> UpdateBed(int id, BedDto bedDto)
        {
            var existingBed = await _context.Beds.FindAsync(id);
            if (existingBed == null)
                return null; // hoặc throw exception nếu cần

            existingBed.RoomNumber = bedDto.RoomNumber;
            existingBed.DepartmentID = bedDto.DepartmentID;
            existingBed.Status = bedDto.Status;
            existingBed.PatientID = bedDto.PatientID;

            await _context.SaveChangesAsync();
            return existingBed;
        }


        public async Task<bool> DeleteBed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed == null)
                return false;

            _context.Beds.Remove(bed);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
