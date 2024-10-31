using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs.Response
{
    public class WorkResponseDto
    {
        public int WorkId { get; set; }
        public int EstimatedHoursWorked { get; set; }
        public DateTime DeadLine { get; set; }
        public decimal CostPrice { get; set; }

        // Lista de Items
        public List<ItemResponseDto> ItemsId { get; set; }
        public string StatusSerialized { get; set; }
        public string Notes { get; set; }
    }
}
