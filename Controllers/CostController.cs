using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]/cost")]
    [ApiController]
    public class CostController : ControllerBase
    {

       
        private readonly CostService _costService;

        public CostController(CostService costService)
        {
            this._costService = costService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ClientDto>>> GetClientes()
        {
            var costs = await _costService.GetAllAsync();
            return Ok(costs);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveCost(CostDto costDto)
        {
            var result = await _costService.SaveAsync(costDto);
            if (result)
            {
                return Ok("Costo guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el costo.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CostDto>> GetCostById(int id)
        {
            var cost = await _costService.GetByIdAsync(id);
            if (cost == null)
            {
                return NotFound();
            }

            return Ok(cost);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateCostById(int id, CostDto costDto)
        {
            costDto.IdCost = id; // Ensure the ID is set correctly for updating
            var result = await _costService.UpdateAsync(costDto);
            if (result)
            {
                return Ok("Costo actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el costo.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteCostById(int id)
        {
            try
            {
                var result = await _costService.DeleteAsync(id);
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
