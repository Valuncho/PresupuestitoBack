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

        // Relación con Client
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; } // Clave foránea

        public Client Oclient { get; set; } // Propiedad de navegación


        //List Budgets
        public ICollection<Budget> Budgets { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Status { get; set; }

    }
}
