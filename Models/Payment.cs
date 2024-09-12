using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [Column(TypeName = "INT")]
        public int PaymentId { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public double Amount { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(400)")]
        public string DescriptionPayment { get; set; }

        [Required]        
        [ForeignKey("IdInvoice")]
        public int IdInvoice { get; set; }

        public Invoice OInvoice { get; set; }

        [Required]
        [ForeignKey("IdBudget")]
        public int IdBudget { get; set; }
        
        public Budget OBudget { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

    }
}
