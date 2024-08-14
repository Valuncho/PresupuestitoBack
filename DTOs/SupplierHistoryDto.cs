using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class SupplierHistoryDto
    {
        public int SupplierHistoryId { get; set; }
        public Supplier OSupplier { get; set; }
        public List<Invoice> OInvoiceList { get; set; }
    }
}
