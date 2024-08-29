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
        private readonly WorkService workService;


        public WorkController(WorkService workService)
        {
            this.workService = workService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<WorkDto>>> GetWorks()
        {
            var works = await workService.GetAllAsync();
            return Ok(works);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveWork (WorkDto workDto)
        {
            var result = await workService.SaveAsync(workDto);
            if (result)
            {
                return Ok("Trabajo guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el trabajo.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WorkDto>> GetWorkById(int id)
        {
            var work = await workService.GetByIdAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            return Ok(work);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateWorkById(int id, WorkDto workDto)
        {
            workDto.IdWork = id; // Ensure the ID is set correctly for updating
            var result = await workService.UpdateAsync(workDto);
            if (result)
            {
                return Ok("Cliente actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el cliente.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteWorkById(int id)
        {
            try
            {
                var result = await workService.DeleteAsync(id);
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
