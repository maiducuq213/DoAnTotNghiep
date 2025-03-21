namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MedicalRecord :BaseEntity
    {
        
        [Required]
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }  // Navigation Property

        [Required]
        [ForeignKey("Staff")]
        public int StaffID { get; set; }
        public Staff? Staff { get; set; }  // Navigation Property

        [Required]
        public string Diagnosis { get; set; }

        public string? Prescription { get; set; }

        public string TreatmentPlan { get; set; }

        [Required]
        public DateTime VisitDate { get; set; } = DateTime.Now;
    }

}
