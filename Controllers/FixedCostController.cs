using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/FixedCost")]
    public class FixedCostController : ControllerBase
    {
        private readonly FixedCostService _fixedCostService;


        public FixedCostController(FixedCostService fixedCostService)
        {
            this._fixedCostService = fixedCostService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<FixedCostDto>>> GetFixedCost()
        {
            var fixedCosts = await _fixedCostService.GetAllAsync();
            return Ok(fixedCosts);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveFixedCost(FixedCostDto fixedCostDto)
        {
            var result = await _fixedCostService.SaveAsync(fixedCostDto);
            if (result)
            {
                return Ok("Costo fijo guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el costo fijo.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FixedCostDto>> GetFixedCostById(int id)
        {
            var fixedCost = await _fixedCostService.GetByIdAsync(id);
            if (fixedCost == null)
            {
                return NotFound();
            }

            return Ok(fixedCost);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateFixedCostById(int id, FixedCostDto requestDto)
        {
            requestDto.IdFixedCost = id; // Ensure the ID is set correctly for updating
            var result = await _fixedCostService.UpdateAsync(requestDto);
            if (result)
            {
                return Ok("Costo Fijo actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el costo Fijo.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteFixedCostById(int id)
        {
            try
            {
                var result = await _fixedCostService.DeleteAsync(id);
                if (result)
                {
                    return Ok("Registro eliminado :)");
                }
                return BadRequest("No se pudo eliminar el registro.");
            }
            catch (Exception ex)
            {
                return BadRequest($"No se pudo eliminar el registro. El error es: {ex.Message}");
            }
        }
    }
}
