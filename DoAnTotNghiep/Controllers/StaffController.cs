using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using DoAnTotNghiep.Services.Implementations;
using DoAnTotNghiep.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllStaffs()
        {
            var staffs = await _staffService.GetAllStaff();
            return Ok(staffs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getStaffById(int id)
        {
            var staff = await _staffService.GetStaffById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }
        [HttpPost]
        public async Task<IActionResult> createStaff([FromBody]StaffDto staffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createStaff = await _staffService.AddStaff(staffDto);
            return CreatedAtAction(nameof(getStaffById), new { id = createStaff.Id }, createStaff);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateStaff(int id, [FromBody] StaffDto staffDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateStaff = await _staffService.UpdateStaff(id,staffDto);
            if (updateStaff == null)
            {
                return NotFound();
            }
            return Ok(updateStaff);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var result = await _staffService.DeleteStaff(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
