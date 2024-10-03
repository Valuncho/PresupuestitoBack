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

        [Required]
        [ForeignKey("IdMaterial")]
        public int IdMaterial { get; set; }        
        public Material OMaterial { get; set; }

        [Required]
        [ForeignKey("IdWork")]
        public int IdWork { get; set; }     
        public Work OWork { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }
    }
}
