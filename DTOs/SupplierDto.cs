using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class SupplierDto
    {
        public int IdSupplier { get; set; }
        public Person OPerson { get; set; }
        public bool Status { get; set; }
    }
}
