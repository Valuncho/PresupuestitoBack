using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Materials")]
    public class Material
    {
        [Key]
        [Column(TypeName = "INT")]
        public int MaterialId { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string MaterialName { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(400)")]
        public string MaterialDescription { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string MaterialColor { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string MaterialBrand { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string MaterialMeasure { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string MaterialUnitMeasure { get; set; }

        // Relación con SubCategory
        [Required]
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; } // Clave foránea

        public SubCategoryMaterial OSubcategory { get; set; } // Propiedad de navegación


        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

    }
}