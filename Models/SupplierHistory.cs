using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SupplierHistories")]
    public class SupplierHistory
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdSupplierHistory { get; set; }


        [Required]       
        public int IdSupplier { get; set; }
        [ForeignKey("IdSupplier")]
        public Supplier OSupplier { get; set; }


        [Required]      
        public int IdMaterial { get; set; }
        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string QuantityMaterial { get; set; }


        [Required]
        [Column(TypeName = "DATE")]
        public DateTime PurchaseDateMaterial { get; set; }


        [Required]
        [Column(TypeName = "DECIMAL(20,2)")]
        public decimal PricePerUnitMaterial { get; set; }


        [Required]
        [Column(TypeName = "DECIMAL(20,2)")]
        public decimal PriceTotal {  get; set; }

        //List Invoice
        public ICollection<Invoice> Invoices { get; set; }

    } 
}
