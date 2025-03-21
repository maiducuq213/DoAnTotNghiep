using DoAnTotNghiep.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        public async Task<IActionResult> getAllStaffs()
        {
            var staffs = await _staffService.GetAllStaff();
            return Ok(staffs);
        }
    }
}
