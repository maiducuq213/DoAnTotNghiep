using DoAnTotNghiep.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.Models
{
    public class Department: BaseEntity
    {
        
        [Required]
        [StringLength(100)]
        public string  DepartmentName { get; set; }

        public string Description { get; set; }
    }
}
