using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs
{
    public class MaterialDto
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public string MaterialColor { get; set; }
        public string MaterialBrand { get; set; }
        public string MaterialMeasure { get; set; }
        public string MaterialUnitMeasure { get; set; }
        public SubCategory OSubCategory { get; set; }
    }
}
