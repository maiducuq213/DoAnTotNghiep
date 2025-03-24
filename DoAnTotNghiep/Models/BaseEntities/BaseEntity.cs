using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.Models.BaseEntities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Khóa chính

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo

        public string? CreatedBy { get; set; } // ID người tạo

        public DateTime? UpdatedAt { get; set; } // Ngày cập nhật

        public string? UpdatedBy { get; set; } // ID người cập nhật

        public DateTime? DeletedAt { get; set; } // Ngày xóa (nếu có)

        [Required]
        public bool IsDeleted { get; set; } = false; // Soft delete
    }

}
