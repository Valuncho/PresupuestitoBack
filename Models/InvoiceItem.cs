using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("InvoiceItems")]
    public class InvoiceItem
    {
        [Key]
        public int IdInvoiceItem { get; set; }
<<<<<<< HEAD
        [Required]
=======


        public int IdMaterial { get; set; }
>>>>>>> d57bafa (add Model Invoice and InvoiceItem)
        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; }
        [Required]
<<<<<<< HEAD
        public decimal Quantity { get; set; }
=======
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }   


>>>>>>> d57bafa (add Model Invoice and InvoiceItem)
        [Required]
        public decimal Price { get; set; }
    }
}
