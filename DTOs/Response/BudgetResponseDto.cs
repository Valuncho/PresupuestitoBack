using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs.Response
{
    public class BudgetResponseDto
    {
        public int IdBudget { get; set; }
        public List<WorkResponseDto> Works { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionBudget { get; set; }
        public List<PaymentResponseDto> Payments { get; set; }
        public ClientResponseDto OClient { get; set; }
    }
}
