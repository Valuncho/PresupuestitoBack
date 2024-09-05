namespace PresupuestitoBack.DTOs
{
    public class BudgetDto
    {
        public int IdBudget { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionBudget { get; set; }
        //falta list de works and Payments
        public bool Status { get; set; }

    }
}
