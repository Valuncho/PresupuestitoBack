using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.Models
{
    [Table("EmployeeHistories")]
    public class EmployeeHistory
    {
        [Key]
        [Column("IdEmployeeHistory", TypeName = "INT")]
        public int IdEmployeeHistory { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        // Relación con Employee
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; } // Clave foránea

        public Employee OEmployee { get; set; } // Propiedad de navegación
    }
}
