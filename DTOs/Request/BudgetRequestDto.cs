namespace PresupuestitoBack.DTOs.Request
{
    public class BudgetRequestDto
    {
        public List<int> Works { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionBudget { get; set; }
        public List<int> Payments { get; set; }
        public int OCliente { get; set; }

    }
}
