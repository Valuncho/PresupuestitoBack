using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Works")]
    public class Work
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdWork { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int EstimatedHoursWorked { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DeadLine { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal CostPrice { get; set; }

        // Lista de Items
        public ICollection<Item> OMaterials { get; set; } = new List<Item>();

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Notes { get; set; }

        // Relación con Budget (Presupuesto)
        [Required]
        public int BudgetId { get; set; } // Clave foránea

        [ForeignKey("BudgetId")]
        public Budget OBudget { get; set; } // Propiedad de navegación
    }
}





