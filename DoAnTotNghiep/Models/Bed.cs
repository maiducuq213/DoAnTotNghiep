namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bed:BaseEntity
    {

        [Required]
        [StringLength(10)]
        public string? RoomNumber { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }  // Navigation Property

        [Required]
        public BedStatus Status { get; set; } = BedStatus.Available;

        [ForeignKey("Patient")]
        public int? PatientID { get; set; }  // NULL nếu giường trống
        public Patient? Patient { get; set; }  // Navigation Property
    }

    // Enum trạng thái giường bệnh
    public enum BedStatus
    {
        Available,
        Occupied,
        Maintenance
    }

}
