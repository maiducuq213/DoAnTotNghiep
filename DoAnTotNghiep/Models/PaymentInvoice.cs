namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaymentInvoice : BaseEntity
    {


        //    [Required]
        //    public int PatientID { get; set; }
        //    public Patient Patient { get; set; }

        //    //[Required]
        //    //public DateTime InvoiceDate { get; set; } = DateTime.Now; // Ngày tạo hóa đơn

        //    [Required]
        //    [Column(TypeName = "decimal(10,2)")]
        //    public decimal TotalAmount { get; set; } // Tổng số tiền hóa đơn

        //    public string TransactionID { get; set; } // Mã giao dịch của cổng thanh toán (VNPay, Momo)

        //    [Required]
        //    public PaymentGateway PaymentGateway { get; set; } = PaymentGateway.VNPay; // Phương thức thanh toán

        //    [Required]
        //    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending; // Trạng thái thanh toán

        //    public string PaymentURL { get; set; } // URL thanh toán VNPay

        //    public List<PaymentInvoiceDetail> InvoiceDetails { get; set; } // Danh sách dịch vụ, thuốc
        //}

        //public class PaymentInvoiceDetail
        //{
        //    [Key]
        //    public int InvoiceDetailID { get; set; }

        //    [Required]
        //    public int PaymentInvoiceID { get; set; }
        //    public PaymentInvoice PaymentInvoice { get; set; }

        //    [Required]
        //    public string Description { get; set; }  // Dịch vụ: "Khám bệnh", "Thuốc XYZ"
        //    [Required]
        //    [Column(TypeName = "decimal(10,2)")]
        //    public decimal Price { get; set; } // Giá mỗi dịch vụ
        //    public int Quantity { get; set; } = 1; // Số lượng
        //}

        //// Enum PaymentGateway
        //public enum PaymentGateway
        //{
        //    VNPay,
        //    Momo
        //}

        //// Enum PaymentStatus
        //public enum PaymentStatus
        //{
        //    Pending,   // Chưa thanh toán
        //    Success,   // Đã thanh toán
        //    Failed,    // Thanh toán thất bại
        //    Refunded   // Đã hoàn tiền
        //}
        public int PatientId { get; set; }  // Liên kết với bảng Patient
        public Patient Patient { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }  // Tổng tiền (chưa giảm giá)
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }     // Giảm giá
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalAmount { get; set; }  // Thành tiền sau khi giảm giá
        public int TreatmentDays { get; set; }


        public string PaymentMethod { get; set; } // Phương thức thanh toán

        public string PaymentURL { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; } = PaymentStatusEnum.Pending;
        public PaymentGatewayOptions PaymentGateway { get; set; } = PaymentGatewayOptions.VNPay;

        public List<InvoiceDetail> InvoiceDetails { get; set; } // Chi tiết thuốc

        public List<InvoiceService> InvoiceServices { get; set; } // Chi tiết dịch vụ

        public enum PaymentGatewayOptions
        {
            VNPay,
            Momo
        }
        public enum PaymentStatusEnum
        {
            Pending,   // Chưa thanh toán
            Success,   // Đã thanh toán
            Failed,    // Thanh toán thất bại
            Refunded   // Đã hoàn tiền
        }
    }
}