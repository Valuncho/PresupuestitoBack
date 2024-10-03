using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("InvoicesItems")]
    public class InvoiceItem
    {
        [Key]
        public int IdInvoiceItem { get; set; }
        
        [ForeignKey("IdMaterial")]
        public int IdMaterial { get; set; }        
        public Material OMaterial { get; set; } 

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }


        [Required]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; } 
        public Invoice OInvoice { get; set; } 
    }
}

