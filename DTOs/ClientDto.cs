using PresupuestitoBack.Models;
namespace PresupuestitoBack.DTOs
{
    public class ClientDto
    {
        public int IdClient { get; set; }
        public Person OPerson { get; set; }
        // falta la list de ClientHistory
        public bool Status { get; set; }
    }
}
