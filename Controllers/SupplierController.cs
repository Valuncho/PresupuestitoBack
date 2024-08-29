using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    public class SupplierController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SupplierService _supplierService;

        public SupplierController(IMapper mapper, SupplierService supplierService)
        {
            _mapper = mapper;
            _supplierService = supplierService;
        }
        [HttpGet("{id}", Name = "GetSupplierById")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var supplier = await _supplierService.GetByIdAsync(id);
            if (supplier != null)
            {
                return Ok(_mapper.Map<SupplierDto>(supplier));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<SupplierDto>>> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllAsync();
            return Ok(_mapper.Map<List<SupplierDto>>(suppliers));
        }
        [HttpDelete]
        public async Task<ActionResult<SupplierDto>> Delete(int IdSupplier)
        {
            if (IdSupplier == 0)
            {
                return BadRequest();
            }
            else
            {
                await _supplierService.Delete(IdSupplier);
                return NoContent();
            }
        }
    }
}
