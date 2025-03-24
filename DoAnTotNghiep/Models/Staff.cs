namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Staff:BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

       

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }  // Navigation Property

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Address { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

    }

   
}
