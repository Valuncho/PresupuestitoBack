using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class EmployeeDto
    {
        public int IdEmployee { get; set; }
        public Person OPerson { get; set; }
        public decimal Salary { get; set; }
        public bool Status { get; set; }
    }
}
