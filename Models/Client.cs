using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        [ForeignKey("IdPerson")]
        public int IdPerson { get; set; }
        public virtual Person OPerson { get; set; }

        public virtual ICollection<ClientHistory> ClientsHistory { get; set; } 

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get => Status; set { Status = true; } }

    }
}