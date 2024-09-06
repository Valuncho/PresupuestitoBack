using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierHistoryController : ControllerBase
    {
        private readonly SupplierHistoryService supplierHistoryService;

        public SupplierHistoryController(SupplierHistoryService supplierHistoryService)
        {
            this.supplierHistoryService = supplierHistoryService;
        }

        [HttpPost]
        public async Task CreateSupplierHistory(SupplierHistoryDto supplierHistoryDto)
        {
            await supplierHistoryService.CreateSupplierHistory(supplierHistoryDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateSupplierHistory(SupplierHistoryDto supplierHistoryDto)
        {
            await supplierHistoryService.UpdateSupplierHistory(supplierHistoryDto);
        }

        [HttpGet("{id}")]
        public async Task<SupplierHistoryDto> GetSupplierHistoryById(int id)
        {
            return await supplierHistoryService.GetSupplierHistoryById(id);
        }

        [HttpGet]
        public async Task<List<SupplierHistoryDto>> GetSupplierHistories()
        {
            return await supplierHistoryService.GetSupplierHistories();
        }
    }
}
