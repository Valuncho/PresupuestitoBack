using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
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
    }
}
