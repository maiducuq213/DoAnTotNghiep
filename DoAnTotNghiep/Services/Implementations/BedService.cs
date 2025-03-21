namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;

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

        public async Task<Bed> GetBedById(int id)
        {
            return await _context.Beds.Include(b => b.Department)
                                        .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Bed> AddBed(Bed bed)
        {
            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();
            return bed;
        }

        public async Task<Bed> UpdateBed(int id, Bed bed)
        {
            var existingBed = await _context.Beds.FindAsync(id);
            if (existingBed == null)
                return null; // hoặc throw exception nếu cần

            existingBed.RoomNumber = bed.RoomNumber;
            existingBed.DepartmentID = bed.DepartmentID;
            existingBed.Status = bed.Status;
            existingBed.PatientID = bed.PatientID;

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
