using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

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
        [Column(TypeName = "DATETIME")]
        public DateTime BillDate { get; set; }

        [Required]
        [ForeignKey("IdPayment")]
        public int IdPayments { get; set; }
        public virtual Payment OPayment { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }
    }
}
