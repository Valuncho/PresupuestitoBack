using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.DTOs
{
    public class CostDto
    {
        public int IdCost { get; set; }
        public decimal CostValue { get; set; }
        public string Description { get; set; }
        public string TypeSerialized { get; set; }
    }
}
