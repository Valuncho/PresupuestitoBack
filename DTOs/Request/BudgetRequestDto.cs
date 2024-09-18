namespace PresupuestitoBack.DTOs.Request
{
    public class BudgetRequestDto
    {
        public List<int> WorksId { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionBudget { get; set; }
        public List<int> PaymentsId { get; set; }
        public int ClienteId { get; set; }

    }
}
