namespace DoAnTotNghiep.DTOs
{
    using DoAnTotNghiep.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class BedDto
    {
        public string? RoomNumber { get; set; }
        public int DepartmentID { get; set; }
        public BedStatus Status { get; set; } = BedStatus.Available;
        public int? PatientID { get; set; }  // NULL nếu giường trống
    }
}
