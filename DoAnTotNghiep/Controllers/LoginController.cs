using DoAnTotNghiep.Models.API;
using DoAnTotNghiep.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public LoginController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel req)
        {
            var result = await _jwtService.Authenticate(req);
            if(req is null)
            {
                return Unauthorized();
            }
            return result;
        }
    }
}
