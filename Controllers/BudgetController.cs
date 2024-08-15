using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BudgetService _budgetService;

        public BudgetController(IMapper mapper, BudgetService budgetService)
        {
            _mapper = mapper;
            _budgetService = budgetService;
        }
        [HttpGet("{id}", Name = "GetBudgetById")]
        public async Task<ActionResult<BudgetDto>> GetBudget(int id)
        {
            /*if (id == 0)
            {
                return BadRequest();
            }*/

            var budget = await _budgetService.GetByIdAsync(id);
            if (budget != null)
            {
                return Ok(_mapper.Map<BudgetDto>(budget));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<BudgetDto>>> GetAllPersons()
        {
            var budgets = await _budgetService.GetAllAsync();
            return Ok(_mapper.Map<List<BudgetDto>>(budgets));
        }
        [HttpDelete]
        public async Task<ActionResult<BudgetDto>> Delete(int IdBudget)
        {
            if (IdBudget == 0)
            {
                return BadRequest();
            }
            else
            {
                await _budgetService.Delete(IdBudget);
                return NoContent();
            }
        }
    }
}