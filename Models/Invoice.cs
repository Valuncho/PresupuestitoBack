using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
<<<<<<< HEAD
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
=======
    [Table("Invoice")]
    public class Invoice
    {
        
        [Key]
        [Column(TypeName = "INT")]
        public int IdInvoice { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsPaid { get; set; }

        //List Payments
        public ICollection<Payment> Payment { get; set; }



>>>>>>> eb81f80 (addd model InvoiceItem)
    }
}
