using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Budgets")]
    public class Budget
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdBudget { get; set; }

        [ForeignKey("IdClient")]
        public Client OClient { get; set; }

        //List Works
        public ICollection<Work> Works { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Cost { get; set; }


    }
}
