using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("IdEmployee", TypeName = "INT")]
        public int IdEmployee { get; set; }

        [Required]
        [ForeignKey("IdPerson")]
        public int IdPerson { get; set; }
        public Person OPerson { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Salary { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }

    }
}
