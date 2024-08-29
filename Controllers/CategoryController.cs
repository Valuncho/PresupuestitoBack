using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task createCategory(CategoryDto categoryDto)
        {
            await categoryService.createCategory(categoryDto);
        }

        [HttpPut("{id}")]
        public async Task updateCategory(CategoryDto categoryDto)
        {
            await categoryService.updateCategory(categoryDto);
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> getCategoryById(int id)
        {
            return await categoryService.getCategoryById(id);           
        }

        public async Task<List<CategoryDto>> getCategories()
        {
            return await categoryService.getCategories();
        }
    }
}
