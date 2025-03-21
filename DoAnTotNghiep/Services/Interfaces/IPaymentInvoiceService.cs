using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IPaymentInvoiceService
    {
        Task<PaymentInvoice> CreateInvoiceAsync(PaymentInvoice invoice); // Tạo hóa đơn mới
        Task<PaymentInvoice> GetInvoiceByIdAsync(int id); // Lấy hóa đơn theo ID
        Task<IEnumerable<PaymentInvoice>> GetAllInvoicesAsync(); // Lấy danh sách hóa đơn
        Task<bool> UpdatePaymentStatusAsync(int id, PaymentStatus status); // Cập nhật trạng thái thanh toán
        Task<string> GeneratePaymentURLAsync(int invoiceId, PaymentGateway gateway); // Tạo URL thanh toán QR
    }
}
