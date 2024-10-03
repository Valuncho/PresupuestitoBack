namespace PresupuestitoBack.DTOs.Response
{
    public class SubCategoryMaterialResponseDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public CategoryResponseDto categoryId { get; set; }
    }
}
