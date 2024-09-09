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
        public int IdPerson { get; set; }

        [ForeignKey("IdPerson")]
        public Person OPerson { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Salary { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        // Relación con EmployeeHistory (Historial del empleado)
        public ICollection<EmployeeHistory> Histories { get; set; } = new List<EmployeeHistory>(); // Propiedad de navegación
    }
}
