using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetService budgetService;

        public BudgetController(BudgetService budgetService)
        {
            this.budgetService = budgetService;
        }

        [HttpPost]
        public async Task CreateBudget([FromBody] BudgetRequestDto budgetRequestDto)
        {
            await budgetService.CreateBudget(budgetRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateBudget(int id, [FromBody] BudgetRequestDto budgetRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await budgetService.UpdateBudget(id, budgetRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetResponseDto>> GetBudgetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var budget = await budgetService.GetBudgetById(id);
            return(Ok(budget));
        }

        [HttpGet]
        public async Task<ActionResult<List<BudgetResponseDto>>> GetBudgets()
        {
            return await budgetService.GetAllBudgets();
        }

        [HttpPatch("{id}")]
        public async Task DeleteBudget(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await budgetService.DeleteBudget(id);
        }

    }
}