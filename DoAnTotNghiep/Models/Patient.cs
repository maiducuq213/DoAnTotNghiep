using DoAnTotNghiep.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Models
{
    public class Patient: BaseEntity
    {
        
        [Required]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string EmergencyContact { get; set; }
        [Required]

        public string MedicalHistory { get; set; }

    }
}
