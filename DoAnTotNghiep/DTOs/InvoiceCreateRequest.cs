namespace DoAnTotNghiep.DTOs
{
    public class InvoiceCreateRequest
    {
        public int PatientId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentURL { get; set; }
        public List<MedicineRequestDto> Medicines { get; set; }
        public List<ServiceRequestDto> Services { get; set; }
    }
}
