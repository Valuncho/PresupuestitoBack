using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Salaries")]
    public class Salary
    {
        [Key]
        public int IdSalary { get; set; }


        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Amount { get; set; }


        [Required]
        [Column(TypeName = "DATEONLY")]
        public DateOnly BillDate { get; set; }


        [Required]
        public int IdPayments { get; set; }
        [ForeignKey("IdPayment")]
        public Payment OPayment { get; set; }
    }
}
