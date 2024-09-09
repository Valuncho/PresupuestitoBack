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

        // Relación con Supplier
        [Required]
        [ForeignKey("IdSupplier")]
        public int SuplierId { get; set; } // Clave foránea

        public Supplier Osupplier { get; set; } // Propiedad de navegación

        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

    } 
}
