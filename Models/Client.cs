using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PresupuestitoBack.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [Column(TypeName = "INT")]
        public int IdClient { get; set; }

      
        public int IdPerson { get; set; }
        [ForeignKey("IdPerson")]
        public Person OPerson { get; set; }

    }
}