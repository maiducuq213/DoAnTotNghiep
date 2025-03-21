using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IBedService
    {
        Task<IEnumerable<Bed>> GetAllBeds();
        Task<Bed> GetBedById(int id);
        Task<Bed> AddBed(Bed bed);
        Task<Bed> UpdateBed(int id, Bed bed);
        Task<bool> DeleteBed(int id);
    }
}
