namespace PresupuestitoBack.DTOs.Request
{
    public class InvoiceRequestDto
    {
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public int SupplierHistoryId { get; set; }
        public List<int> PaymentsId { get; set; }
        public List<int> InvoiceItemsId { get; set; }

    }
}
