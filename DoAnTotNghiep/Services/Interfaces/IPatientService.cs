using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient?> GetPatientById(int id);
        Task<Patient> AddPatient(PatientDto patientDto);
        Task<Patient?> UpdatePatient(int id, PatientDto patientDto);
        Task<bool> DeletePatient(int id);
    }
}
