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

        //List Works
        public ICollection<Work> Works { get; set; } = new List<Work>(); // Propiedad de navegación

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(400)")]
        public string DescriptionBudget { get; set; }

        //List Payments
        public ICollection<Payment> Payments { get; set; }


        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        // Relación con ClientHistory 
        [Required]
        [ForeignKey("ClientHistory")]
        public int ClientHistoryId { get; set; } // Clave foránea

        public ClientHistory OclientHistory { get; set; } // Propiedad de navegación

    }
}
