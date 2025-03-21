namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Appointment: BaseEntity
    {
        
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient? patient { get; set; }

        [ForeignKey("Staff")]
        public int StaffID { get; set; }
        public Staff? staff { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus  Status { get; set; }   //Enum

        public string? Note { get; set; }

    }
    public enum AppointmentStatus
    {
        Pending,
        Confirm,
        Complete,
        Cancelled
    }
}
