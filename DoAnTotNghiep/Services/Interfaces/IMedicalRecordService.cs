using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> GetAllRecords();
        Task<MedicalRecord> GetRecordById(int id);
        Task<MedicalRecord> AddRecord(MedicalRecordDto recordDto);
        Task<MedicalRecord> UpdateRecord(int id, MedicalRecordDto recordDto);
        Task<bool> DeleteRecord(int id);
    }
}
