using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [Column("IdSupplier", TypeName = "INT")]
        public int IdSupplier { get; set; }

        // Clave foránea hacia Person
        [Required]
        public int IdPerson { get; set; }

        // Relación con la clase Person
        [ForeignKey("IdPerson")]
        public Person OPerson { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        public ICollection<SupplierHistory> SupplierHistorys { get; set;} = new List<SupplierHistory>();
    }
}

