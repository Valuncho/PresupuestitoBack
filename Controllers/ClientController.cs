using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService clientService;        

        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;           
        }

        [HttpPost]
        public async Task CreateClient([FromBody] ClientRequestDto clientRequestDto)
        {
            await clientService.CreateClient(clientRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateClient(int id, [FromBody] ClientRequestDto clientRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await clientService.UpdateClient(id, clientRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientReponseDto>> GetClientById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var client = await clientService.GetClientById(id);
            return Ok(client);
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientReponseDto>>> GetAllClients()
        {
            return await clientService.GetAllClients();
        }

        [HttpPatch("{id}")]
        public async Task DeleteClient(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await clientService.DeleteClient(id);
        }
    }
}