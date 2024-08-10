using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [Column("IdSupplier", TypeName = "INT")]
        public int IdSupplier { get; set; }


        [Required]
        public int IdPerson { get; set; }
        [ForeignKey("IdPerson")]
        public Person OPerson { get; set; }
    }
}
