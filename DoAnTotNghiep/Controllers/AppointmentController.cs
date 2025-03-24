using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.Implementations;
using DoAnTotNghiep.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getAppointmentById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        [HttpPost]
        public async Task<IActionResult> createAppointment([FromBody] AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createAppointment = await _appointmentService.AddAppointment(appointmentDto);
            return CreatedAtAction(nameof(getAppointmentById), new { id = createAppointment.Id }, createAppointment);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateBed(int id, [FromBody] AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateAppointment = await _appointmentService.UpdateAppointment(id, appointmentDto);
            if (updateAppointment == null)
            {
                return NotFound();
            }
            return Ok(updateAppointment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAppointment(int id)
        {
            var result = await _appointmentService.DeleteAppointment(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
