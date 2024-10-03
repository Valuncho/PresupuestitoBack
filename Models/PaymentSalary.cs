﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("PaymentsSalary")]
    public class PaymentSalary
    {
        [Key]
        [Column(TypeName = "INT")]
        public int PaymentSalaryId { get; set; }

        [Required]
        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }
        public virtual Payment OPayment { get; set; }

        [Required]
        [ForeignKey("SalaryId")]
        public int SalaryId { get; set; }
        public virtual Salary OSalary { get; set; }

        [Column(TypeName = ("bit"))]
        public bool Status { get => Status; set { Status = true; } }
    }
}