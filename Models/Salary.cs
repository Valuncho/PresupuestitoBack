using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace PresupuestitoBack.Models
{
    [Table("Salaries")]
    public class Salary
    {
        [Key]
        [Column("SalaryId", TypeName = "INT")]
        public int SalaryId { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime BillDate { get; set; }

        [Required]
        [ForeignKey("PaymentId")]
        public int PaymentsId { get; set; }
        public virtual Payment OPayment { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }
    }
}
