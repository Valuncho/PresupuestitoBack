namespace PresupuestitoBack.DTOs.Response
{
    public class InvoiceResponseDto
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public List<SupplierHistoryResponseDto> OSupplierHistory { get; set; }
        public List<PaymentResponseDto> OPayments  { get; set; }
        public List<InvoiceItemResponseDto> OInvoiceItems { get; set; }
    }
}
