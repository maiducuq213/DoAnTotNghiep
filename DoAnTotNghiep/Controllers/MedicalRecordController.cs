using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllMedicalRecord()
        {
            var medicalRecords = await _medicalRecordService.GetAllRecords();
            return Ok(medicalRecords);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getMedicalRecord(int id)
        {
            var medicalRecord = await _medicalRecordService.GetRecordById(id);
            if (medicalRecord == null) return NotFound();
            return Ok(medicalRecord);
        }
        [HttpPost]
        public async Task<IActionResult> addMedicalRecord([FromBody]MedicalRecordDto medicalRecordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var medicalRecord = CreateMedicalRecord(medicalRecordDto);
            var create = await _medicalRecordService.AddRecord(medicalRecord);
            return CreatedAtAction(nameof(getMedicalRecord), new { id = create.Id }, create);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateMedicalRecord(int id,[FromBody] MedicalRecordDto medicalRecordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var medicalRecord = CreateMedicalRecord(medicalRecordDto);
            var update = await _medicalRecordService.UpdateRecord(id,medicalRecord);
            if (update == null)
            {
                return NotFound();
            }
            return Ok(update);
        }

        public MedicalRecord CreateMedicalRecord(MedicalRecordDto medicalRecord)
        {
            return new MedicalRecord
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                PatientID = medicalRecord.PatientID,
                StaffID = medicalRecord.StaffID,
                TreatmentPlan = medicalRecord.TreatmentPlan,
                Diagnosis = medicalRecord.Diagnosis,
                Prescription = medicalRecord.Prescription,
                VisitDate = medicalRecord.VisitDate,
                DeletedAt =null,
                UpdatedAt=null,
                UpdatedBy = null,
                CreatedBy= null,
            };

        }
    }
    
}
