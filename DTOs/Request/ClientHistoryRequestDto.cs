namespace PresupuestitoBack.DTOs.Request
{
    public class ClientHistoryRequestDto
    {
        public int IdClient {  get; set; }
        public List<int> IdBudgets { get; set; }
    }
}
