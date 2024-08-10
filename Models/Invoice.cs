using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int IdInvoice { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public List<Payment> Payments { get; set; }
        [Required]
        public bool IsPiad { get; set; }
        [Required]
        public List<Item> Items { get; set; }
    }
}
