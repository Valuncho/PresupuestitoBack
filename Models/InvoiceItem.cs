using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("InvoicesItems")]
    public class InvoiceItem
    {
        [Key]
        public int IdInvoiceItem { get; set; }

        // Relación con Material
        public int IdMaterial { get; set; }

        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; } // Propiedad de navegación para el Material

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        // Relación con Invoice
        [Required]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; } // Clave foránea

        public Invoice OInvoice { get; set; } // Propiedad de navegación para la Invoice
    }
}

