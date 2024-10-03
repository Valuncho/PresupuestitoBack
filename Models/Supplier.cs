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
        [ForeignKey("IdPerson")]
        public int IdPerson { get; set; }
        public virtual Person OPerson { get; set; }

        [Column(TypeName = ("bit"))]
        public bool Status { get => Status; set { Status = true; } }

    }
}

