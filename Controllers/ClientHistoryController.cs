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
        private readonly IMapper mapper;

        public ClientHistoryController(ClientHistoryService clientHistoryService, IMapper mapper)
        {
            this.clientHistoryService = clientHistoryService;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<ClientHistoryDto>>> GetClientesHistory()
        {
            var clientsHistorys = await clientHistoryService.GetAllAsync();
            var clientsHistorysDto = mapper.Map<List<ClientDto>>(clientsHistorys);
            return Ok(clientsHistorysDto);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveClienteHistory(ClientHistoryDto clienteHistoryDto)
        {
            var clientHistory = mapper.Map<ClientHistory>(clienteHistoryDto);
            var result = await clientHistoryService.SaveAsync(clientHistory);
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
            var clientHistoryDto = mapper.Map<ClientHistoryDto>(clientHistory);
            return Ok(clientHistoryDto);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateClienteHistoryById(int id, ClientHistoryDto requestDto)
        {
            var clientHistory = mapper.Map<ClientHistory>(requestDto);
            clientHistory.IdClientHistory = id; // Ensure the ID is set correctly for updating
            var result = await clientHistoryService.UpdateAsync(clientHistory);
            if (result)
            {
                return Ok("ClienteHistory actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el clienteHistory.");
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