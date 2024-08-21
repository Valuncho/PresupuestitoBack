using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]/work")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly WorkService _workService;

        public WorkController(IMapper mapper, WorkService workService)
        {
            _mapper = mapper;
            _workService = workService;
        }
        [HttpGet("{id}", Name = "GetWorkById")]
        public async Task<ActionResult<WorkDto>> GetWork(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var work = await _workService.GetByIdAsync(id);
            if (work != null)
            {
                return Ok(_mapper.Map<WorkDto>(work));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<WorkDto>>> GetAllWorks()
        {
            var works = await _workService.GetAllAsync();
            return Ok(_mapper.Map<List<WorkDto>>(works));
        }
        [HttpDelete]
        public async Task<ActionResult<WorkDto>> Delete(int IdWork)
        {
            if (IdWork == 0)
            {
                return BadRequest();
            }
            else
            {
                await _workService.Delete(IdWork);
                return NoContent();
            }
        }
    }
}
