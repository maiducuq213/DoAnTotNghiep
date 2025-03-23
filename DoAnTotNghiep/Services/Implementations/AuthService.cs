//using DoAnTotNghiep.Services.Interfaces;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using DoAnTotNghiep.Models;
//namespace DoAnTotNghiep.Services.Implementations
//{
//    public class AuthService: IAuthService
//    {
//        private readonly IConfiguration _config;

//        public AuthService(IConfiguration config)
//        {
//            _config = config;
//        }

//        public string GenerateJwtToken(UserAccount user)
//        {
//            var jwtSettings = _config.GetSection("Jwt");
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
//            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                new Claim(ClaimTypes.Role, user.Role)a
//            };

//            var token = new JwtSecurityToken(
//                issuer: jwtSettings["Issuer"],
//                audience: jwtSettings["Audience"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
//                signingCredentials: credentials
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        public bool ValidateUserCredentials(string username, string password, out UserAccount user)
//        {
//            // Giả lập kiểm tra từ Database (bạn có thể thay bằng DB thực tế)
//            if (username == "admin" && password == "password")
//            {
//                user = new UserAccount { Username = "admin", Role = "Admin" };
//                return true;
//            }

//            user = null;
//            return false;
//        }
//    }
//}
