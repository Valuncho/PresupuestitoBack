using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("InvoicesItems")]
    public class InvoiceItem
    {
        [Key]
        public int IdInvoiceItem { get; set; }

        public int IdMaterial { get; set; }
        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; }
        
        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }   

        [Required]
        public decimal Price { get; set; }


        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
    }
}
