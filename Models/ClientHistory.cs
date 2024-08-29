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


        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public Person OClient { get; set; }


        //List Budgets
        public ICollection<Budget> Budgets { get; set; }

    }
}
