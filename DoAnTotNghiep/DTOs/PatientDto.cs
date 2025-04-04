using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.DTOs
{
    public class PatientDto
    {
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
        public string ImgPath { get; set; }
        [Required]

        public string EmergencyContact { get; set; }
        [Required]

        public string MedicalHistory { get; set; }
    }
}
