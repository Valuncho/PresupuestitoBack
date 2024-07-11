using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("ClientsHistorys")]
    public class ClientHistory
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdClientHistory { get; set; }

        //List payments
        public ICollection<Payment> Payments { get; set; }


        [ForeignKey("IdClient")]
        public Client Client { get; set; }

    }
}
