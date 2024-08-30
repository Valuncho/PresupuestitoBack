using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/Salary")]
    public class SalaryController : ControllerBase
    {
        private readonly SalaryService _salaryService;


        public SalaryController(SalaryService salaryService)
        {
            this._salaryService = salaryService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<SalaryDto>>> GetSalarios()
        {
            var salaries = await _salaryService.GetAllAsync();
            return Ok(salaries);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveSalario(SalaryDto salaryDto)
        {
            var result = await _salaryService.SaveAsync(salaryDto);
            if (result)
            {
                return Ok("Salary guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el salary.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryDto>> GetSalaryById(int id)
        {
            var salary = await _salaryService.GetByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }

            return Ok(salary);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateSalaryById(int id, SalaryDto requestDto)
        {
            requestDto.IdSalary = id; // Ensure the ID is set correctly for updating
            var result = await _salaryService.UpdateAsync(requestDto);
            if (result)
            {
                return Ok("Salario actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el salario.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSalaryById(int id)
        {
            try
            {
                var result = await _salaryService.DeleteAsync(id);
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
