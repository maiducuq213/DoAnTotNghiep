using DoAnTotNghiep.DTOs;
using DoAnTotNghiep.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentInvoiceController : ControllerBase
    {
        private readonly IPaymentInvoiceService _paymentInvoiceService;

        public PaymentInvoiceController(IPaymentInvoiceService paymentInvoiceService)
        {
            _paymentInvoiceService = paymentInvoiceService;
        }
        [HttpPost]
        public async Task<IActionResult> updateInvoice([FromBody] InvoiceCreateRequest invoiceCreateRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updateStaff = await _paymentInvoiceService.CreateInvoiceAsync(invoiceCreateRequest);
                return Ok(updateStaff);
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }
    }
}
