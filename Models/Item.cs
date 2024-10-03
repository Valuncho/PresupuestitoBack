using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [Column("ItemId",TypeName = "INT")]
        public int ItemId { get; set; }

        [Required]
        [ForeignKey("MaterialId")]
        public int MaterialId { get; set; }        
        public virtual Material OMaterial { get; set; }

        [Required]
        [ForeignKey("WorkId")]
        public int WorkId { get; set; }     
        public Work OWork { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }
    }
}
