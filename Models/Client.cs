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

        [Required]
        [Column(TypeName = "INT")]
        public Person Person { get; set; }


    }
}