using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    public class SupplierHistoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SupplierHistoryService _supplierHistoryService;

        public SupplierHistoryController(IMapper mapper, SupplierHistoryService supplierHistoryService)
        {
            _mapper = mapper;
            _supplierHistoryService = supplierHistoryService;
        }
        [HttpGet("{id}", Name = "GetSupplierHistoryById")]
        public async Task<ActionResult<SupplierHistoryDto>> GetSupplierHistory(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var supplierHistory = await _supplierHistoryService.GetByIdAsync(id);
            if (supplierHistory != null)
            {
                return Ok(_mapper.Map<SupplierHistoryDto>(supplierHistory));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<SupplierHistoryDto>>> GetAllSupplierHistory()
        {
            var supplierHistorys = await _supplierHistoryService.GetAllAsync();
            return Ok(_mapper.Map<List<SupplierHistoryDto>>(supplierHistorys));
        }
        [HttpDelete]
        public async Task<ActionResult<SupplierHistoryDto>> Delete(int IdSupplierHistory)
        {
            if (IdSupplierHistory == 0)
            {
                return BadRequest();
            }
            else
            {
                await _supplierHistoryService.Delete(IdSupplierHistory);
                return NoContent();
            }
        }
    }
}
