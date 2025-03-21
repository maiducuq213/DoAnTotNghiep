using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.DTOs
{
    public class MedicalRecordDto
    {
        public int PatientID { get; set; }
        public int StaffID { get; set; }
       
        public string Diagnosis { get; set; }

        public string? Prescription { get; set; }

        public string TreatmentPlan { get; set; }

        public DateTime VisitDate { get; set; } = DateTime.Now;
    }
}
