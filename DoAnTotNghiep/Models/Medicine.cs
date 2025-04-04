using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Tên thuốc
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Giá tiền
    }

}
