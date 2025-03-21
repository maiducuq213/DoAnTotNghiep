using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> GetAllRecords();
        Task<MedicalRecord> GetRecordById(int id);
        Task<MedicalRecord> AddRecord(MedicalRecord record);
        Task<MedicalRecord> UpdateRecord(int id, MedicalRecord record);
        Task<bool> DeleteRecord(int id);
    }
}
