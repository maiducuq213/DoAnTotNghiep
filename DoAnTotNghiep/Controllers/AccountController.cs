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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> registerAccount(AccountDto accountDto)
        {
            try
            {
                var registerAccount = await _accountService.RegisterAccount(accountDto);
                return Ok(new { message = "Đăng ký tài khoản thành công!",registerAccount });
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("{userName}")]
        public async Task<IActionResult> updateStaff(string userName, [FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateAccount = await _accountService.UpdateAccount(userName, accountDto);
            if (updateAccount == null)
            {
                return NotFound();
            }
            return Ok(updateAccount);
        }
    }
}
