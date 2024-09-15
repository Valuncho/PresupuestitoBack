namespace PresupuestitoBack.DTOs.Response
{
    public class ClientHistoryResponseDto
    {
        public int ClientHistoryId { get; set; }
        public ClientResponseDto OClient {  get; set; }
        public List<BudgetResponseDto> OBudgets { get; set; }
    }
}
