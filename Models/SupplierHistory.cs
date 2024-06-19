using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SupplierHistories")]
    public class SupplierHistory
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdSupplier { get; set; }

        /*[Required]
        [Column(TypeName = "INT")]
        public Supplier Supplier { get; set; }*/

        [Required]
        [Column(TypeName = "INT")]
        public Material Material { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string QuantityMaterial { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime PurchaseDateMaterial {  get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal PriceMaterial { get; set; }
    } 
}
