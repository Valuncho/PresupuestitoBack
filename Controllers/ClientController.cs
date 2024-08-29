using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;

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
        

        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
            
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ClientDto>>> GetClientes()
        {
            var clients = await clientService.GetAllAsync();
            return Ok(clients);
        }

       
        [HttpPost("new")]
        public async Task<ActionResult> SaveCliente(ClientDto clienteDto)
        {
            var result = await clientService.SaveAsync(clienteDto);
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
            
            return Ok(client);
        }

       
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateClienteById(int id, ClientDto requestDto)
        {
            requestDto.IdClient = id; // Ensure the ID is set correctly for updating
            var result = await clientService.UpdateAsync(requestDto);
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