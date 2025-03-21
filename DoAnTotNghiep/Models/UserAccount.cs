using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoAnTotNghiep.Models.BaseEntities;

namespace DoAnTotNghiep.Models
{
    public class UserAccount :BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public bool IsActive { get; set; } = true;

        // Liên kết 1-1 với Staff
        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public Staff Staff { get; set; }
    }
}
    