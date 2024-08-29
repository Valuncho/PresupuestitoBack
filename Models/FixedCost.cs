using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
<<<<<<< HEAD
    [Table("FixedCost")]
    public class FixedCost
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdFixedCost { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Description { get; set; }


        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Amount { get; set; }


        [Required]
        [Column(TypeName = "INT")]
        public int WorkingDays { get; set; }


        [Required]
        [Column(TypeName = "INT")]
        public int HoursWorked { get; set; }


        [Required]
        [Column(TypeName = "DATE")]
        public DateOnly DateCharged {  get; set; }

=======
    [Table("FixedCosts")]
    public class FixedCost
    {
        [Key]
        public int IdFixedCost { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int WorkingDays { get; set; }
        [Required]
        public int HoursWorked { get; set;}
        [Required]
        public DateOnly Date {  get; set; }
>>>>>>> b3b5ee65de5514b1748bc2e7b49aeb7b0b1afa4c
    }
}
