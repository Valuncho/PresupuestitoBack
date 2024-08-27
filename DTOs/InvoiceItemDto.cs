using PresupuestitoBack.Models;
namespace PresupuestitoBack.DTOs
{
    public class InvoiceItemDto
    {
        public int IdInvoiceItem { get; set; }
        public Material Material { get; set; }
        public decimal Quantity{ get; set; }
        public decimal Price{ get; set; }
    }
}
