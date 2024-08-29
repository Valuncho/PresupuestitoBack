using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdItem { get; set; }

        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }
    }
}