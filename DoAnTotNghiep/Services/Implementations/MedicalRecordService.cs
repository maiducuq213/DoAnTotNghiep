namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    using DoAnTotNghiep.DTOs;

    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly HospitalContext _context;
        public MedicalRecordService(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedicalRecord>> GetAllRecords()
        {
            return await _context.MedicalRecords.Include(m => m.Patient).Include(m => m.Staff).ToListAsync();

        }
        public async Task<MedicalRecord?> GetRecordById(int id)
        {
            return await _context.MedicalRecords.Include(m => m.Patient)
                .Include(m => m.Staff).FirstOrDefaultAsync(m => m.Id == id);

        }
        public async Task<MedicalRecord> AddRecord(MedicalRecordDto recordDto)
        {
            var record = new MedicalRecord
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                PatientID = recordDto.PatientID,
                StaffID = recordDto.StaffID,
                TreatmentPlan = recordDto.TreatmentPlan,
                Diagnosis = recordDto.Diagnosis,
                Prescription = recordDto.Prescription,
                VisitDate = recordDto.VisitDate,
                CreatedBy = null
            };
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }
        
        public async Task<MedicalRecord?> UpdateRecord(int id, MedicalRecordDto recordDto)
        {
            var existingRecord = await _context.MedicalRecords.FindAsync(id);
            if (existingRecord == null)
            {
                return null;
            }
            existingRecord.Diagnosis = recordDto.Diagnosis;
            existingRecord.VisitDate = recordDto.VisitDate;
            existingRecord.TreatmentPlan = recordDto.TreatmentPlan;
            existingRecord.Prescription = recordDto.Prescription;
            existingRecord.PatientID = recordDto.PatientID;
            existingRecord.StaffID = recordDto.StaffID;
            await _context.SaveChangesAsync();
            return existingRecord;

        }
        public async Task<bool> DeleteRecord(int id)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord == null)
                return false;
            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
