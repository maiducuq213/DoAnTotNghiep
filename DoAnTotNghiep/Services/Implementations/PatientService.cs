namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    public class PatientService :IPatientService
    {
        private readonly HospitalContext _context;

        public PatientService(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToArrayAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Patient> AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task<Patient> UpdatePatient(int id, Patient patient)
        {
            Patient existingPatient = await _context.Patients.FindAsync(id);
            if(existingPatient == null)
            {
                return null;
            }
            existingPatient.FullName = patient.FullName;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Gender = patient.Gender;
            existingPatient.Address = patient.Address;
            existingPatient.Phone = patient.Phone;
            existingPatient.Email = patient.Email;
            existingPatient.EmergencyContact = patient.EmergencyContact;
            existingPatient.MedicalHistory = patient.MedicalHistory;
            existingPatient.CreatedAt = patient.CreatedAt;
            await _context.SaveChangesAsync();
            return existingPatient;
        }
        public async Task<bool> DeletePatient(int id)
        {
            Patient existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
            {
                return false;
            }
            _context.Patients.Remove(existingPatient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
