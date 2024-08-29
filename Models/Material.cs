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


        [Required]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory OSubCategory { get; set; }

        [Required]
        [Column(TypeName = "Bool")]
        public bool status { get; set; }

    }
}