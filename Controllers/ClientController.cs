using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.DTOs.RequestDTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClientController : ControllerBase
    {


        private readonly ClientService clientService;
        private readonly IMapper mapper;

        public ClientController(ClientService clientService, IMapper mapper)
        {
            this.clientService = clientService;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ClientDto>>> GetClientes()
        {
            var clients = await clientService.GetAllAsync();
            var clientsDto = mapper.Map<List<ClientDto>>(clients);
            return Ok(clientsDto);
        }

       
        [HttpPost("new")]
        public async Task<ActionResult> SaveCliente([FromBody] ClientRequestDto clienteDto)
        {
            var client = mapper.Map<Client>(clienteDto);
            var result = await clientService.SaveAsync(client);
            if (result)
            {
                return Ok("Cliente guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el cliente.");
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClienteById(int id)
        {
            var client = await clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var clientDto = mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

       
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateClienteById(int id, [FromBody] ClientRequestDto requestDto)
        {
            var client = mapper.Map<Client>(requestDto);
            client.IdClient = id; // Ensure the ID is set correctly for updating
            var result = await clientService.UpdateAsync(client);
            if (result)
            {
                return Ok("Cliente actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el cliente.");
        }
        

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteClienteById(int id)
        {
            try
            {
                var result = await clientService.DeleteAsync(id);
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