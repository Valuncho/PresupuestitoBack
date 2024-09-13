using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SubCategories")]
    public class SubCategoryMaterial
    {
        [Key]
        [Column(TypeName = "INT")]
        public int SubCategoryMaterialId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string SubCategoryName { get; set; }

        // Relación con Category
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category OCategory { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
    }
}

