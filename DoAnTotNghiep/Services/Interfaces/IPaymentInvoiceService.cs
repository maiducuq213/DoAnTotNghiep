using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Models;
using static DoAnTotNghiep.Models.PaymentInvoice;

namespace DoAnTotNghiep.Services.Interfaces
{
    public interface IPaymentInvoiceService
    {
        Task<PaymentInvoice> CreateInvoiceAsync(InvoiceCreateRequest invoiceCreateRequest); // Tạo hóa đơn mới
        Task<PaymentInvoice?> GetInvoiceByIdAsync(int id); // Lấy hóa đơn theo ID
        Task<IEnumerable<PaymentInvoice>> GetAllInvoicesAsync(); // Lấy danh sách hóa đơn
        Task<bool> UpdatePaymentStatusAsync(int id, PaymentStatusEnum status); // Cập nhật trạng thái thanh toán
        Task<string> GeneratePaymentURLAsync(int invoiceId, PaymentGatewayOptions gateway); // Tạo URL thanh toán QR
    }
}
