using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {

        private readonly MaterialService materialService;

        public MaterialController(MaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpPost]
        public async Task createMaterial(MaterialDto materialDto)
        {
            await materialService.createMaterial(materialDto);
        }

        [HttpPut("{id}")]
        public async Task updateMaterial(MaterialDto materialDto)
        {
            await materialService.updateMaterial(materialDto);
        }

        [HttpGet("{id}")]
        public async Task<MaterialDto> getMaterialById(int id)
        {
            return await materialService.getMaterialById(id);
        }

        [HttpGet]
        public async Task<List<MaterialDto>> getAllMaterial()
        {
            return await materialService.getMaterials();
        }

    }
}
