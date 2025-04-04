using DoAnTotNghiep.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using static DoAnTotNghiep.Models.PaymentInvoice;

namespace DoAnTotNghiep.Models
{
    public class InvoiceService :BaseEntity
    {
        public int InvoiceId { get; set; }
        public PaymentInvoice Invoice { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Giá dịch vụ
        public DateTime DateAdded { get; set; }
    }

}
