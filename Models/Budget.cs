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

        [Required]
        [Column(TypeName = "INT")]
        public Client Client { get; set; }

        [Required]
        [Column(TypeName = "INT")]//ver tipo de datos en las listas
        public List<Work> Works { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Cost { get; set; }


    }
}
