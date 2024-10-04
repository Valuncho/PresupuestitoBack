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
        [Column("WorkId",TypeName = "INT")]
        public int WorkId { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int EstimatedHoursWorked { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DeadLine { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal CostPrice { get; set; }
        public virtual ICollection<Item> OMaterials { get; set; }

        [Column(TypeName = ("bit"))]
        private bool _Status;
        public bool Status
        {
            get => Status;
            set { Status = value; }
        }

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Notes { get; set; }

        [Required]
        [ForeignKey("BudgetId")]
        public int BudgetId { get; set; } 
        public virtual Budget Budget { get; set; } 

    }
}





