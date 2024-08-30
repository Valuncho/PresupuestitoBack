namespace PresupuestitoBack.DTOs
{
    public class FixedCostDto
    {
        public int IdFixedCost { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int WorkingDays { get; set; }
        public int HoursWorked { get; set; }
        public DateOnly DateCharged { get; set; }
    }
}
