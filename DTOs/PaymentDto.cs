﻿using PresupuestitoBack.Models;
namespace PresupuestitoBack.DTOs
{
    public class PaymentDto
    {
        public int IdPayment { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string DescriptionPayment { get; set; }
        //public Salary OSalary { get; set; }
        public Invoice OInvoice { get; set; }
        public Budget OBudget { get; set; }

    }
}