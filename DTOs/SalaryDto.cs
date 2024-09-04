using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class SalaryDto
    {
        public int IdSalary { get; set; }
        public decimal Amount { get; set; }
        public DateOnly BillDate { get; set; }
        public int IdPayments { get; set; }
        public Payment OPayment { get; set; }
        public bool Status { get; set; }
    }
}
