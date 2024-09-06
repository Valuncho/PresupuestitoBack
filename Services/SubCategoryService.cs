using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SubCategoryService
    {
        private readonly ISubCategoryRepository subCategoryRepository;
        private readonly IMapper mapper;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            this.subCategoryRepository = subCategoryRepository;
            this.mapper = mapper;
        }

        public async Task CreateSubCategory(SubCategoryDto subCategoryDto)
        {
            var subCategory = mapper.Map<SubCategory>(subCategoryDto);
            await subCategoryRepository.Insert(subCategory);
        }

        public async Task UpdateSubCategory(SubCategoryDto subCategoryDto)
        {
            var existingSubCategory = await subCategoryRepository.GetById(s => s.SubCategoryId == subCategoryDto.SubCategoryId);
            if (existingSubCategory == null)
            {
                throw new KeyNotFoundException("La sub categoria no existe");
            }
            else
            {
                var subCategory = mapper.Map<SubCategory>(subCategoryDto);
                await subCategoryRepository.Update(subCategory);
            }            
        }

        public async Task<SubCategoryDto> GetSubCategoryById(int id)
        {
            var subCategory = await subCategoryRepository.GetById(s => s.SubCategoryId == id);
            if(subCategory == null)
            {
                throw new KeyNotFoundException("La sub categoria no fue encontrada");
            }
            else
            {
                return mapper.Map<SubCategoryDto>(subCategory);
            }
        }

        public async Task<List<SubCategoryDto>> GetAllSubCategories()
        {
            var subCategories = await subCategoryRepository.GetAll();
            return mapper.Map<List<SubCategoryDto>>(subCategories);
        }
    }
}
