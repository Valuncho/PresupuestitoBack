namespace PresupuestitoBack.DTOs.Request
{
    public class ClientHistoryRequestDto
    {
        public int OClient {  get; set; }
        public List<int> BudgetsId { get; set; }
    }
}
