using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdCategory { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string NameCategory { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string ModelCategory { get; set; }


        [Required]
        public int IdSubCategory { get; set; }
        [ForeignKey("IdSubCategory")]
        public SubCategory OSubCategory { get; set; }
    }
}
