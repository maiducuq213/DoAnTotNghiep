namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    using DoAnTotNghiep.DTOs;

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
        public async Task<Patient> AddPatient(PatientDto patientDto)
        {
            var patient = new Patient
            {
                FullName = patientDto.FullName,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Address = patientDto.Address,
                Phone = patientDto.Phone,
                Email = patientDto.Email,
                EmergencyContact = patientDto.EmergencyContact,
                MedicalHistory = patientDto.MedicalHistory,
                
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task<Patient?> UpdatePatient(int id, PatientDto patientDto)
        {
            Patient? existingPatient = await _context.Patients.FindAsync(id);
            if(existingPatient == null)
            {
                return null;
            }
            existingPatient.FullName = patientDto.FullName;
            existingPatient.DateOfBirth = patientDto.DateOfBirth;
            existingPatient.Gender = patientDto.Gender;
            existingPatient.Address = patientDto.Address;
            existingPatient.Phone = patientDto.Phone;
            existingPatient.Email = patientDto.Email;
            existingPatient.EmergencyContact = patientDto.EmergencyContact;
            existingPatient.MedicalHistory = patientDto.MedicalHistory;
            existingPatient.UpdatedAt = DateTime.Now;
            existingPatient.UpdatedBy = null;
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
