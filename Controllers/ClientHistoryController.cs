using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]/ClientHistory")]
    [ApiController]
    public class ClientHistoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClientHistoryService _clientHistoryService;

        public ClientHistoryController(IMapper mapper, ClientHistoryService clientHistoryService)
        {
            _mapper = mapper;
            _clientHistoryService = clientHistoryService;
        }
        [HttpGet("{id}", Name = "GetClientHistoryById")]
        public async Task<ActionResult<ClientHistoryDto>> GetClient(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var clientHistory = await _clientHistoryService.GetByIdAsync(id);
            if (clientHistory != null)
            {
                return Ok(_mapper.Map<ClientHistoryDto>(clientHistory));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<ClientHistoryDto>>> GetAllClientsHistorys()
        {
            var clientsHistorys = await _clientHistoryService.GetAllAsync();
            return Ok(_mapper.Map<List<ClientHistoryDto>>(clientsHistorys));
        }
        [HttpDelete]
        public async Task<ActionResult<ClientHistoryDto>> Delete(int IdClientHistory)
        {
            if (IdClientHistory == 0)
            {
                return BadRequest();
            }
            else
            {
                await _clientHistoryService.Delete(IdClientHistory);
                return NoContent();
            }
        }
    }
}