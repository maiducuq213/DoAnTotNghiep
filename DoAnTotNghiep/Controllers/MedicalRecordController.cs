﻿using DoAnTotNghiep.DTOs;
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
            var create = await _medicalRecordService.AddRecord(medicalRecordDto);
            return CreatedAtAction(nameof(getMedicalRecord), new { id = create.Id }, create);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateMedicalRecord(int id,[FromBody] MedicalRecordDto medicalRecordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _medicalRecordService.UpdateRecord(id, medicalRecordDto);
            if (update == null)
            {
                return NotFound();
            }
            return Ok(update);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteMedicalRecord(int id)
        {
            var result = await _medicalRecordService.DeleteRecord(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }   
}
