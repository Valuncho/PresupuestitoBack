using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class MaterialService 
    {
        private readonly IMaterialRepository materialRepository;
        private readonly Mapper mapper;

        public MaterialService(IMaterialRepository materialRepository, Mapper mapper)
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
            var material = mapper.Map<Material>(materialDto);
            await materialRepository.Update(material);
        }

        public async Task<MaterialDto> getMaterialById(int id)
        {
            var material = await materialRepository.GetById(id);
            return mapper.Map<MaterialDto>(material);
        }

        public async Task<List<MaterialDto>> getMaterials()
        {
            var materials = await materialRepository.GetAll();
            return mapper.Map<List<MaterialDto>>(materials);
        }

    }
}
