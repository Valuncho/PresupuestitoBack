using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class SupplierHistoryDto
    {
        public int IdSupplierHistory { get; set; }
        public Supplier OSupplier { get; set; }
        public Material OMaterial { get; set; }
        public string QuantityMaterial { get; set; }
        public DateTime PurchaseDateMaterial { get; set; }
        public decimal PricePerUnitMaterial { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
