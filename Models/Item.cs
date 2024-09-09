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

        // Clave foránea hacia Material
        [Required]
        public int IdMaterial { get; set; }

        // Relación con la clase Material
        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; }

        // Clave foránea hacia Work
        [Required]
        public int IdWork { get; set; }

        // Relación con la clase Work
        [ForeignKey("IdWork")]
        public Work OWork { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
    }
}
