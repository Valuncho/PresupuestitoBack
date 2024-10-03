﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SupplierHistories")]
    public class SupplierHistory
    {
        [Key]
        [Column("SupplierHistoryId",TypeName = "INT")]
        public int SupplierHistoryId { get; set; }

        [Required]
        [ForeignKey("SupplierId")]
        public int SuplierId { get; set; } 
        public virtual Supplier Osupplier { get; set; }

        [Column(TypeName = ("bit"))]
        public bool Status { get => Status; set { Status = true; } }

    } 
}
