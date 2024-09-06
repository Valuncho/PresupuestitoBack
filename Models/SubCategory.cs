using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Key]
        [Column(TypeName = "INT")]
        public int SubCategoryId { get; set; }  


        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string SubCategoryName {  get; set; }


        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category OCategory { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

    }
}
