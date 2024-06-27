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

        [Required]
        [Column(TypeName = "INT")] //ver tipo de datos en las listas
        public List<Payment> Payments { get; set; }

        [Required]
        [Column(TypeName = "INT")] 
        public Client Client { get; set; }

    }
}
