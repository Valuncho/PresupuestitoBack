using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PresupuestitoBack.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column(TypeName = "INT")]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string CategoryName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string CategoryModel { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        // Propiedad de navegación para las SubCategories
        public ICollection<SubCategoryMaterial> SubCategories { get; set; } = new List<SubCategoryMaterial>();
    }
}
