using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class SubCategoryDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public Category OCategory { get; set; }
    }
}
