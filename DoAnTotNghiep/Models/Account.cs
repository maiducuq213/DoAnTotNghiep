using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoAnTotNghiep.Models.BaseEntities;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class Account :BaseEntity
    {

        [Required]
        [StringLength(50)]

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public StaffRole Role { get; set; }  // Sử dụng Enum
        public bool IsActive { get; set; } = true;

        // Liên kết 1-1 với Staff
        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public Staff Staff { get; set; }

    }
    // Enum để định nghĩa Role của Staff
    public enum StaffRole
    {
        [EnumMember(Value = "Doctor")]
        Doctor,

        [EnumMember(Value = "Nurse")]
        Nurse,

        [EnumMember(Value = "Technician")]
        Technician,

        [EnumMember(Value = "Admin")]
        Admin
    }

}
