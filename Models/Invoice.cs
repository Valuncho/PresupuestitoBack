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

        // Relación con SupplierHistory
        [Required]
        [ForeignKey("SupplierHistory")]
        public int SuplierHistoryId { get; set; } // Clave foránea
        public SupplierHistory OSupplierHistory { get; set; } // Propiedad de navegación

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }



    }
}
