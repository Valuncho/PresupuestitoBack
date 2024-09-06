using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class EmployeeHistoryDto
    {
        public int IdEmployeeHistory { get; set; }
        public Employee OEmployee { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
