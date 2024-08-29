using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/Budget")]
    public class BudgetController : ControllerBase
    {


        private readonly BudgetService budgetService;


        public BudgetController(BudgetService budgetService)
        {
            this.budgetService = budgetService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<BudgetDto>>> GetBudgets()
        {
            var budgets = await budgetService.GetAllAsync();
            return Ok(budgets);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveBudget(BudgetDto budgetDto)
        {
            var result = await budgetService.SaveAsync(budgetDto);
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

            return Ok(budget);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateBudgetById(int id, BudgetDto requestDto)
        {
            requestDto.IdBudget = id; // Ensure the ID is set correctly for updating
            var result = await budgetService.UpdateAsync(requestDto);
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