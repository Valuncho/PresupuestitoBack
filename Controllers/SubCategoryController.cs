using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly SubCategoryService subCategoryService;

        public SubCategoryController(SubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }

        [HttpPost]
        public async Task CreateSubCategory(SubCategoryDto subCategoryDto)
        {
            await subCategoryService.CreateSubCategory(subCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateSubCategory(SubCategoryDto subCategoryDto)
        {
            await subCategoryService.UpdateSubCategory(subCategoryDto);
        }
                       
        [HttpGet("{id}")]
        public async Task<SubCategoryDto> GetSubCategoryById(int id)
        {
            return await subCategoryService.GetSubCategoryById(id);          
        }

        [HttpGet]
        public async Task<List<SubCategoryDto>> getAllSubCategories()
        {
            return await subCategoryService.GetAllSubCategories();
        }

    }
}
