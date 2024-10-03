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

<<<<<<< HEAD
        // Lista de Items
        public ICollection<Item> OMaterials { get; set; } = new List<Item>();
=======
        public virtual ICollection<Item> Materials { get; set; }

        [Column(TypeName = ("bit"))]
        public bool Status { get => Status; set { Status = true; } }
>>>>>>> e123f0df7fcca694f1ecdfb27c067c0ac5d1e441

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Notes { get; set; }

        [Required]
        [ForeignKey("BudgetId")]
<<<<<<< HEAD
        public Budget OBudget { get; set; } // Propiedad de navegación
=======
        public int BudgetId { get; set; } 
        public Budget Budget { get; set; } 

>>>>>>> e123f0df7fcca694f1ecdfb27c067c0ac5d1e441
    }
}





