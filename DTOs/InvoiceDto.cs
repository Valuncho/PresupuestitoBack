using PresupuestitoBack.Models;
namespace PresupuestitoBack.DTOs
{
    public class InvoiceDto
    {
        public int IdInvoice { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public SupplierHistory OSupplierHistory { get; set; }
        // falta list de payments and InvoiceItems
        public bool Status { get; set; }
    }
}
