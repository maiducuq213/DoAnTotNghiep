using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> AddPatient(Patient patient);
        Task<Patient> UpdatePatient(int id, Patient patient);
        Task<bool> DeletePatient(int id);
    }
}
