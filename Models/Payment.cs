using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdPayment { get; set; }

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
        public int IdInvoice { get; set; }
        [ForeignKey("IdInvoice")]
        public Invoice OInvoice { get; set; }

        [Required]
        public int IdBudget { get; set; }
        [ForeignKey("IdBudget")]
        public Budget OBudget { get; set; }

        [Required]
        [Column(TypeName = "Bool")]
        public bool Status { get; set; }

    }
}
