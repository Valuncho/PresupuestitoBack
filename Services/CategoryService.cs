using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task CreateCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);     
            await categoryRepository.Insert(category);
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var existingCategory = await categoryRepository.GetById(c => c.CategoryId == categoryDto.CategoryId);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("La categoria no existe.");
            }
            else
            {
                var category = mapper.Map<Category>(categoryDto);
                await categoryRepository.Update(category);
            }               
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await categoryRepository.GetById(c => c.CategoryId == id);
            if (category == null)
            {
                throw new KeyNotFoundException("La categoria no fue encontrada.");
            }
            else
            {
                return mapper.Map<CategoryDto>(category);
            }           
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var categories = await categoryRepository.GetAll();           
            return mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
