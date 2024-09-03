using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class MaterialService 
    {
        private readonly IMaterialRepository materialRepository;
        private readonly IMapper mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            this.materialRepository = materialRepository;
            this.mapper = mapper;
        }

        public async Task createMaterial(MaterialDto materialDto)
        {
            var material = mapper.Map<Material>(materialDto);
            await materialRepository.Insert(material);
        }

        public async Task updateMaterial(MaterialDto materialDto)
        {
            var existingMaterial = await materialRepository.GetById(m => m.MaterialId == materialDto.MaterialId);
            if (existingMaterial == null)
            {
                throw new KeyNotFoundException("El material no existe");
            }
            else
            {
                var material = mapper.Map<Material>(materialDto);
                await materialRepository.Update(material);                
            }
        }
        
        public async Task<MaterialDto> getMaterialById(int id)
        {
            var material = await materialRepository.GetById(m => m.MaterialId == id);
            if (material == null)
            {
                throw new KeyNotFoundException("Material no encontrado.");
            }
            else
            {
                return mapper.Map<MaterialDto>(material);
            }            
        }

        public async Task<List<MaterialDto>> getMaterials()
        {
            var materials = await materialRepository.GetAll();
            return mapper.Map<List<MaterialDto>>(materials);
        }
    }
}
