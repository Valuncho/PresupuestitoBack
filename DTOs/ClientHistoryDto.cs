using PresupuestitoBack.Models;
namespace PresupuestitoBack.DTOs
{
    public class ClientHistoryDto
    {
        public int IdClientHistory { get; set; }
        public Client OClient { get; set; }
        // falta list de Budgets
        public bool Status { get; set; }
    }
}
