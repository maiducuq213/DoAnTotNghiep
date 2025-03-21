namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    public class PaymentInvoiceService : IPaymentInvoiceService
    {
        private readonly HospitalContext _context;

        public PaymentInvoiceService(HospitalContext context)
        {
            _context = context;
        }

        public async Task<PaymentInvoice> CreateInvoiceAsync(PaymentInvoice invoice)
        {
            _context.PaymentInvoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<PaymentInvoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.PaymentInvoices
                .Include(i => i.InvoiceDetails)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<PaymentInvoice>> GetAllInvoicesAsync()
        {
            return await _context.PaymentInvoices
                .Include(i => i.InvoiceDetails)
                .ToListAsync();
        }

        public async Task<bool> UpdatePaymentStatusAsync(int id, PaymentStatus status)
        {
            var invoice = await _context.PaymentInvoices.FindAsync(id);
            if (invoice == null)
                return false;

            invoice.PaymentStatus = status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> GeneratePaymentURLAsync(int invoiceId, PaymentGateway gateway)
        {
            var invoice = await _context.PaymentInvoices.FindAsync(invoiceId);
            if (invoice == null)
                return null;

            // Giả lập tạo URL thanh toán VNPay hoặc Momo
            string baseUrl = gateway == PaymentGateway.VNPay
                ? "https://sandbox.vnpayment.vn/payment/"
                : "https://momo.vn/payment/";

            invoice.PaymentURL = $"{baseUrl}?amount={invoice.TotalAmount}&id={invoiceId}";
            await _context.SaveChangesAsync();

            return invoice.PaymentURL;
        }
    }
}
