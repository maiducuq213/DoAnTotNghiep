using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IBedService
    {
        Task<IEnumerable<Bed>> GetAllBeds();
        Task<Bed?> GetBedById(int id);
        Task<Bed> AddBed(BedDto bedDto);
        Task<Bed?> UpdateBed(int id, BedDto bedDto);
        Task<bool> DeleteBed(int id);
    }
}
