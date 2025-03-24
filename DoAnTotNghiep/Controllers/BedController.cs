using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.Implementations;
using DoAnTotNghiep.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : ControllerBase
    {
        private readonly IBedService _bedService;

        public BedController(IBedService bedService)
        {
            _bedService = bedService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllBeds()
        {
            var beds = await _bedService.GetAllBeds();
            return Ok(beds);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getBedById(int id)
        {
            var bed = await _bedService.GetBedById(id);
            if (bed == null)
            {
                return NotFound();
            }
            return Ok(bed);
        }
        [HttpPost]
        public async Task<IActionResult> createBed([FromBody] BedDto bedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createBed = await _bedService.AddBed(bedDto);
            return CreatedAtAction(nameof(getBedById), new { id = createBed.Id }, createBed);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateBed(int id, [FromBody] BedDto bedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateBed= await _bedService.UpdateBed(id, bedDto);
            if (updateBed == null)
            {
                return NotFound();
            }
            return Ok(updateBed);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBed(int id)
        {
            var result = await _bedService.DeleteBed(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
