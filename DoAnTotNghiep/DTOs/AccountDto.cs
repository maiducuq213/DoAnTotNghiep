using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.DTOs
{
    public class AccountDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public StaffRole Role { get; set; }  // Sử dụng Enum
        public bool IsActive { get; set; } = true;
        public int StaffId { get; set; }

    }

}
