using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}
