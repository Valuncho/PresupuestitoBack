﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("ClientsHistorys")]
    public class ClientHistory
    {
        [Key]
        [Column("ClientHistoryId",TypeName = "INT")]
        public int ClientHistoryId { get; set; }

        [Required]
        [ForeignKey("ClientId")]
        public int ClientId { get; set; } 
        public virtual Client Oclient { get; set; } 

        public virtual ICollection<Budget> Budgets { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }

    }
}
