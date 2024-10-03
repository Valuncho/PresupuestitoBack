using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Budgets")]
    public class Budget
    {
        [Key]
        [Column("BudgetId",TypeName = "INT")]
        public int BudgetId { get; set; }
        public virtual ICollection<Work> Works { get; set; } 

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(400)")]
        public string DescriptionBudget { get; set; }

        //List Payments
        public virtual ICollection<Payment> Payments { get; set; }


        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }

        // Relación con ClientHistory 
        [Required]
        [ForeignKey("ClientHistoryId")]
        public int ClientHistoryId { get; set; } // Clave foránea
        public virtual ClientHistory OclientHistory { get; set; } // Propiedad de navegación

    }
}
