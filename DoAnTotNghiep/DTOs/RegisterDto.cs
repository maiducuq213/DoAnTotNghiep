using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int StaffId { get; set; }  // Liên kết với Staff

        [Required]
        public StaffRole Role { get; set; }  // Chỉ cho phép Admin và Technician
    }

}
