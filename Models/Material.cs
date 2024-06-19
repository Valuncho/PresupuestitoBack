using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Materials")]
    public class Material
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdMaterial { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string NameMaterial { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(400)")]
        public string DescriptionMaterial { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string ColorMaterial { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string BrandMaterial { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string MeasureMaterial { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string UnitMeasureMaterial { get; set; }
    }
}
