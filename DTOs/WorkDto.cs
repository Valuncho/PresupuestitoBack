using Newtonsoft.Json;
using PresupuestitoBack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.DTOs
{
    public class WorkDto
    {
        public int IdWork { get; set; }
        public int EstimatedHoursWorked { get; set; }
        public DateTime DeadLine { get; set; }
        public decimal CostPrice { get; set; }

        // Lista de Items
        public ICollection<Item> Materials { get; set; }
        public string StatusSerialized { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
