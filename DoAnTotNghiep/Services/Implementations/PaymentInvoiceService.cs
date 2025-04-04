namespace DoAnTotNghiep.Services.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DoAnTotNghiep.Data;
    using DoAnTotNghiep.Models;
    using DoAnTotNghiep.Services.Interfaces;
    using static DoAnTotNghiep.Models.PaymentInvoice;
    using DoAnTotNghiep.DTOs;

    public class PaymentInvoiceService : IPaymentInvoiceService
    {
        private readonly HospitalContext _context;

        public PaymentInvoiceService(HospitalContext context)
        {
            _context = context;
        }

        public async Task<PaymentInvoice> CreateInvoiceAsync(InvoiceCreateRequest invoiceCreateRequest)
        {
            var invoice = _context.PaymentInvoices
        .Include(i => i.InvoiceDetails)
        .Include(i => i.InvoiceServices)
        .FirstOrDefault(i => i.PatientId == invoiceCreateRequest.PatientId && i.FinalAmount == 0);

            if (invoice == null)
            {
                invoice = new PaymentInvoice
                {
                    PatientId = invoiceCreateRequest.PatientId,
                    PaymentMethod = invoiceCreateRequest.PaymentMethod,
                    InvoiceDetails = new List<InvoiceDetail>(),
                    InvoiceServices = new List<InvoiceService>(),
                    TreatmentDays = 0
                };

                _context.PaymentInvoices.Add(invoice);
            }
            

            decimal totalAmount = invoice.TotalAmount;

            foreach (var item in invoiceCreateRequest.Medicines)
            {
                var medicine = _context.Medicines.Find(item.MedicineId);
                if (medicine != null)
                {
                    var detail = new InvoiceDetail
                    {
                        InvoiceId = invoice.Id,
                        MedicineId = medicine.Id,
                        Quantity = item.Quantity,
                        UnitPrice = medicine.Price,
                        TotalPrice = medicine.Price * item.Quantity,
                        DateAdded = DateTime.Now
                    };
                    invoice.InvoiceDetails.Add(detail);
                    totalAmount += detail.TotalPrice;
                }
            }

            foreach (var item in invoiceCreateRequest.Services)
            {
                var service = _context.Services.Find(item.ServiceId);
                if (service != null)
                {
                    var invoiceService = new InvoiceService
                    {
                        InvoiceId = invoice.Id,
                        ServiceId = service.Id,
                        Price = service.Price,
                        DateAdded = DateTime.Now
                    };
                    invoice.InvoiceServices.Add(invoiceService);
                    totalAmount += service.Price;
                }
            }
            invoice.PaymentURL = "string";
            invoice.TreatmentDays += 1;
            invoice.TotalAmount = totalAmount;
            invoice.FinalAmount = totalAmount - invoice.Discount;
            _context.PaymentInvoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<PaymentInvoice?> GetInvoiceByIdAsync(int id)
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

        public async Task<bool> UpdatePaymentStatusAsync(int id, PaymentStatusEnum status)
        {
            var invoice = await _context.PaymentInvoices.FindAsync(id);
            if (invoice == null)
                return false;

            invoice.PaymentStatus = status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> GeneratePaymentURLAsync(int invoiceId, PaymentGatewayOptions gateway)
        {
            var invoice = await _context.PaymentInvoices.FindAsync(invoiceId);
            if (invoice == null)
                return null;

            // Giả lập tạo URL thanh toán VNPay hoặc Momo
            string baseUrl = gateway == PaymentGatewayOptions.VNPay
                ? "https://sandbox.vnpayment.vn/payment/"
                : "https://momo.vn/payment/";

            invoice.PaymentURL = $"{baseUrl}?amount={invoice.TotalAmount}&id={invoiceId}";
            await _context.SaveChangesAsync();

            return invoice.PaymentURL;
        }
    }
}
