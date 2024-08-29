using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class SupplierHistoryDto
    {
<<<<<<< HEAD
        public int SupplierHistoryId { get; set; }
        public Supplier OSupplier { get; set; }
        public List<Invoice> OInvoiceList { get; set; }
=======
        public int IdSupplierHistory { get; set; }
        public Supplier OSupplier { get; set; }
        public Material OMaterial { get; set; }
        public string QuantityMaterial { get; set; }
        public DateTime PurchaseDateMaterial { get; set; }
        public decimal PricePerUnitMaterial { get; set; }
        public decimal PriceTotal { get; set; }
>>>>>>> ae33ac3b1da52f35ae86f10bfc6ba2e3b76509fd
    }
}
