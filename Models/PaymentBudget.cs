using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("PaymentsBudget")]
    public class PaymentBudget
    {
        [Key]
        [Column(TypeName = "INT")]
        public int PaymentBudgetId { get; set; }

        [Required]
        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }
        public Payment OPayment { get; set; }

        [Required]
        [ForeignKey("BudgetId")]
        public int BudgetId { get; set; }
        public Budget OBudget { get; set; }

        [Column(TypeName = ("bit"))]
        public bool Status { get => Status; set { Status = true; } }

    }
}
