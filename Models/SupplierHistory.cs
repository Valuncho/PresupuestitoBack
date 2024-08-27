using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SupplierHistories")]
    public class SupplierHistory
    {
        [Key]
        [Column(TypeName = "INT")]
        public int SupplierHistoryId { get; set; }


        [Required]       
        public int IdSupplier { get; set; }
        [ForeignKey("IdSupplier")]
        public Supplier OSupplier { get; set; }


        [Required]
        public List<int> Invoices { get; set; }
        [ForeignKey("List<IdInvoices>")]
        public List<Invoice> OInvoices { get; set; }

        //List Invoice
        public ICollection<Invoice> Invoices { get; set; }

    } 
}
