using PresupuestitoBack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.DTOs
{
    public class ItemDao
    {
        public int IdItem { get; set; }
        public Material OMaterial { get; set; }
        public decimal Quantity { get; set; }
    }
}
