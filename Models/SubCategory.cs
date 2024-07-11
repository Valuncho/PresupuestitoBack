using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdSubCategory { get; set; }  


        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string NameSubCategory {  get; set; }


        [Required]
        public int IdMaterial { get; set; }
        [ForeignKey("IdMaterial")]
        public Material OMaterial { get; set; }
    }
}
