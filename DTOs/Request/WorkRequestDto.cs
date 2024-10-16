using PresupuestitoBack.DTOs.Response;

namespace PresupuestitoBack.DTOs.Request
{
    public class WorkRequestDto
    {
        public int EstimatedHoursWorked { get; set; }
        public DateTime DeadLine { get; set; }
        public decimal CostPrice { get; set; }

        // Lista de Items
        public List<int> ItemsId { get; set; }
        public string StatusSerialized { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
    }
}
