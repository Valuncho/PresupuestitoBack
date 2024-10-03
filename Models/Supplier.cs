using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [Column("SupplierId", TypeName = "INT")]
        public int SupplierId { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public virtual Person OPerson { get; set; }

        [Column(TypeName = ("bit"))]
        public bool Status { get => Status; set { Status = true; } }

    }
}

