using static DoAnTotNghiep.Models.PaymentInvoice;
using DoAnTotNghiep.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Models
{
    public class InvoiceDetail : BaseEntity
    {
        public int InvoiceId { get; set; }
        public PaymentInvoice Invoice { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }  // Số lượng thuốc
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // Giá của một đơn vị thuốc
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } // Tổng tiền thuốc
        public DateTime DateAdded { get; set; }
    }

}
