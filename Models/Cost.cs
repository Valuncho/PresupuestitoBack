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
        [Column(TypeName = "VARCHAR(500)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "TEXT")]
        public string TypeSerialized { get; set; }

        [NotMapped]
        public Dictionary<string, object> Type
        {
            get => JsonConvert.DeserializeObject<Dictionary<string, object>>(TypeSerialized);
            set => TypeSerialized = JsonConvert.SerializeObject(value);
        }
    }
}

