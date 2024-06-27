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
        public ICollection<Item> Materials { get; set; }

        [Required]
        [Column(TypeName = "TEXT")]
        public string StatusSerialized { get; set; }

        [NotMapped]
        public Dictionary<string, string> Status
        {
            get => JsonConvert.DeserializeObject<Dictionary<string, string>>(StatusSerialized);
            set => StatusSerialized = JsonConvert.SerializeObject(value);
        }

        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Notes { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Image { get; set; }
    }
}



