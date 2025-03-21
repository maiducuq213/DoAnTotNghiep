namespace DoAnTotNghiep.DTOs
{
    using DoAnTotNghiep.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class DepartmentDto
    {
        public string DepartmentName { get; set; }

        public string Description { get; set; }
    }
}
