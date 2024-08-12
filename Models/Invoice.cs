using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{

    [Table("Invoices")]
    public class Invoice
    {
        
        [Key]
        [Column(TypeName = "INT")]
        public int IdInvoice { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        //List Payments
        public ICollection<Payment> Payment { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsPaid { get; set; }


        //List InvoiceItems
        public ICollection<InvoiceItem> InvoiceItems { get; set; }



    }
}
