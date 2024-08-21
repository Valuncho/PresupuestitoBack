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

        private readonly IMapper _mapper;
        private readonly CostService _costService;

        public CostController(IMapper mapper, CostService costService)
        {
            _mapper = mapper;
            _costService = costService;
        }
        [HttpGet("{id}", Name = "GetCostById")]
        public async Task<ActionResult<CostDto>> GetCost(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var item = await _costService.GetByIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<CostDto>(item));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<CostDto>>> GetAllCost()
        {
            var costs = await _costService.GetAllAsync();
            return Ok(_mapper.Map<List<CostDto>>(costs));
        }
        [HttpDelete]
        public async Task<ActionResult<CostDto>> Delete(int IdCost)
        {
            if (IdCost == 0)
            {
                return BadRequest();
            }
            else
            {
                await _costService.Delete(IdCost);
                return NoContent();
            }
        }
    }
}
