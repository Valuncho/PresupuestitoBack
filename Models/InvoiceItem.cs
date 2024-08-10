using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("InvoiceItems")]
    public class InvoiceItem
    {
        [Key]
        public int IdInvoiceItem { get; set; }
        [Required]
        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
