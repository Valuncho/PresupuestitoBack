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

       

    }
}
