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
        [Column(TypeName = "NVARCHAR(100)")]
        public string MaterialName { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(400)")]
        public string MaterialDescription { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string MaterialColor { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string MaterialBrand { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string MaterialMeasure { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string MaterialUnitMeasure { get; set; }

        [Required]
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; } 
        public virtual SubCategoryMaterial OSubcategory { get; set; } 

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }

    }
}