namespace DoAnTotNghiep.DTOs
{
    using DoAnTotNghiep.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class BedDto
    {
        public string? RoomNumber { get; set; }
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }  // Navigation Property
        public BedStatus Status { get; set; } = BedStatus.Available;
        public int? PatientID { get; set; }  // NULL nếu giường trống
        public Patient? Patient { get; set; }  // Navigation Property
    }
}
