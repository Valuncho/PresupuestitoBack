using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly Mapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, Mapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task createCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            await categoryRepository.Insert(category);
        }

        public async Task updateCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            await categoryRepository.Update(category);
        }

        public async Task<CategoryDto> getCategoryById(int id)
        {
            var category = await categoryRepository.GetById(id);
            return mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> getCategories()
        {
            var categories = await categoryRepository.GetAll();
            return mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
