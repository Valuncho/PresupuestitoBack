using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PresupuestitoBack.Models
{
    [Table("Costs")]
    public class Cost
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdCost { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal CostValue { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Description { get; set; }


        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }
    }
}

