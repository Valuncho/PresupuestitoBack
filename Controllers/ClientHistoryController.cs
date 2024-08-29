using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/clienteHistory")]
    public class ClientHistoryController : ControllerBase
    {


        private readonly ClientHistoryService clientHistoryService;


        public ClientHistoryController(ClientHistoryService clientHistoryService)
        {
            this.clientHistoryService = clientHistoryService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ClientHistoryDto>>> GetClientesHistorys()
        {
            var clientsHistorys = await clientHistoryService.GetAllAsync();
            return Ok(clientsHistorys);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveClienteHistory(ClientHistoryDto clienteHistoryDto)
        {
            var result = await clientHistoryService.SaveAsync(clienteHistoryDto);
            if (result)
            {
                return Ok("ClienteHistory guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el clienteHistory.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClientHistoryDto>> GetClienteHistoryById(int id)
        {
            var clientHistory = await clientHistoryService.GetByIdAsync(id);
            if (clientHistory == null)
            {
                return NotFound();
            }

            return Ok(clientHistory);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateClienteHistoryById(int id, ClientHistoryDto requestDto)
        {
            requestDto.IdClientHistory = id; // Ensure the ID is set correctly for updating
            var result = await clientService.UpdateAsync(requestDto);
            if (result)
            {
                return Ok("Cliente History actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el cliente History.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteClienteHistoryById(int id)
        {
            try
            {
                var result = await clientHistoryService.DeleteAsync(id);
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