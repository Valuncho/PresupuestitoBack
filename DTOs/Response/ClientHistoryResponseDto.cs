namespace PresupuestitoBack.DTOs.Response
{
    public class ClientHistoryResponseDto
    {
        public int ClientHistoryId { get; set; }
        public ClientResponseDto IdClient {  get; set; }
        public List<BudgetResponseDto> IdBudgets { get; set; }
    }
}
