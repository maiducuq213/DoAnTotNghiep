using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DoAnTotNghiep.DTOs
{
    public class AppointmentDto
    {
        public int PatientID { get; set; }

        public int StaffID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }   //Enum

        public string? Note { get; set; }
    }
}
