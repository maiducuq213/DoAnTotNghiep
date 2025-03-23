using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
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
                CreatedAt = DateTime.Now
            };
            var createdPatient = await _patientService.AddPatient(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var patient = new Patient
            {
                FullName = patientDto.FullName,
                DateOfBirth = patientDto.DateOfBirth,
                Gender = patientDto.Gender,
                Address = patientDto.Address,
                Phone = patientDto.Phone,
                Email = patientDto.Email,
                EmergencyContact = patientDto.EmergencyContact,
                MedicalHistory = patientDto.MedicalHistory
            };
            var updatedPatient = await _patientService.UpdatePatient(id, patient);
            if (updatedPatient == null)
                return NotFound();
            return Ok(updatedPatient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatient(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
