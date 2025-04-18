﻿using DoAnTotNghiep.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnTotNghiep.DTOs
{
    public class StaffDto
    {
        public class StaffDTO
        {

            public string FullName { get; set; }

            public StaffRole Role { get; set; }

            public int DepartmentID { get; set; }

            public string Phone { get; set; }

            public string Email { get; set; }

            public string Address { get; set; }

            public DateTime HireDate { get; set; }

            public decimal Salary { get; set; }

            public string? DepartmentName { get; set; } // Thêm thông tin tên phòng ban nếu cần
        }

    }
}
