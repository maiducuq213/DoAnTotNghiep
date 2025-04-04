﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Tên dịch vụ (Khám tổng quát, Xét nghiệm,...)
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Giá tiền
    }

}
