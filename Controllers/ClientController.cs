using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClientService _clientService;

        public ClientController(IMapper mapper, ClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }
        [HttpGet("{id}", Name = "GetClientById")]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            /*if (id == 0)
            {
                return BadRequest();
            }*/

            var client = await _clientService.GetByIdAsync(id);
            if (client != null)
            {
                return Ok(_mapper.Map<ClientDto>(client));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetAllClients()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(_mapper.Map<List<ClientDto>>(clients));
        }
        [HttpDelete]
        public async Task<ActionResult<ClientDto>> Delete(int IdClient)
        {
            if (IdClient == 0)
            {
                return BadRequest();
            }
            else
            {
                await _clientService.Delete(IdClient);
                return NoContent();
            }
        }
    }
}