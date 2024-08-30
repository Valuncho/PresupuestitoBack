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


        [Required]
        [Column(TypeName = "BIT")]
        public bool IsPaid { get; set; }

        [Required]
        public int IdSupplierHistory { get; set; }
        [ForeignKey("IdSupplierHistory")]
        public SupplierHistory OSupplierHistory { get; set; }


        //List Payments
        public ICollection<Payment> Payments { get; set; }


        //List InvoiceItems
        public ICollection<InvoiceItem> InvoiceItems { get; set; }


        [Required]
        [Column(TypeName = "Bool")]
        public bool status { get; set; }



    }
}
