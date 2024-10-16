namespace PresupuestitoBack.DTOs.Request
{
    public class ClientHistoryRequestDto
    {
        public int ClientId {  get; set; }
        public List<int> BudgetsId { get; set; }
    }
}
