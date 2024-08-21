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
    [Route("api/budget")]
    public class BudgetController : ControllerBase
    {


        private readonly BudgetService budgetService;
        private readonly IMapper mapper;

        public BudgetController(BudgetService budgetService, IMapper mapper)
        {
            this.budgetService = budgetService;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<BudgetDto>>> GetBudgets()
        {
            var budgets = await budgetService.GetAllAsync();
            var budgetsDto = mapper.Map<List<BudgetDto>>(budgets);
            return Ok(budgetsDto);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveBudget([FromBody] BudgetRequestDto budgetDto)
        {
            var budget = mapper.Map<Budget>(budgetDto);
            var result = await budgetService.SaveAsync(budget);
            if (result)
            {
                return Ok("Budget guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el Budget.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetDto>> GetBudgetById(int id)
        {
            var budget = await budgetService.GetByIdAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            var budgetDto = mapper.Map<BudgetDto>(budget);
            return Ok(budgetDto);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateBudgetById(int id, [FromBody] BudgetRequestDto requestDto)
        {
            var budget = mapper.Map<Budget>(requestDto);
            budget.IdBudget = id; // Ensure the ID is set correctly for updating
            var result = await budgetService.UpdateAsync(budget);
            if (result)
            {
                return Ok("Budget actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el Budget.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteBudgetById(int id)
        {
            try
            {
                var result = await budgetService.DeleteAsync(id);
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