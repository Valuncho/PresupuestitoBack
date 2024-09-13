using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class BudgetService
    {
        private readonly IBudgetRepository budgetRepository;
        private readonly IMapper mapper;

        public BudgetService(IBudgetRepository budgetRepository, IMapper mapper)
        {
            this.budgetRepository = budgetRepository;
            this.mapper = mapper;
        }
        
        public async Task CreateBudget(BudgetRequestDto budgetRequestDto)
        {
            var budget = mapper.Map<Budget>(budgetRequestDto);
            budget.Status = true;
            await budgetRepository.Insert(budget);
        }

        public async Task UpdateBudget(int id, BudgetRequestDto budgetRequestDto)
        {
            var existyingBudget = await budgetRepository.GetById(b => b.IdBudget == id);
            if (existyingBudget == null)
            {
                throw new Exception("El presupuesto no existe");
            }
            else
            {
                var budget = mapper.Map<Budget>(budgetRequestDto);
                await budgetRepository.Update(budget);
            }
        }

        public async Task<ActionResult<BudgetResponseDto>> GetBudgetById(int id)
        {
            var budget = await budgetRepository.GetById(b => b.IdBudget == id);
            if(budget == null)
            {
                throw new KeyNotFoundException("El presupuesto no fue encontrado");
            }
            else
            {
                return mapper.Map<BudgetResponseDto>(budget);   
            }
        }

        public async Task<ActionResult<List<BudgetResponseDto>>> GetAllBudgets()
        {
            var budgets = await budgetRepository.GetAll();
            if (budgets == null)
            {
                throw new Exception("Presupuestos no encontrados");
            }
            else
            {
                return mapper.Map<List<BudgetResponseDto>>(budgets);    
            }
        }

        public async Task DeleteBudget(int id)
        {
            var budget = await budgetRepository.GetById(b => b.IdBudget == id);
            if (budget == null)
            {
                throw new KeyNotFoundException("El presupuesto no fue encontrado");
            }
            else
            {
                budget.Status = false;
                await budgetRepository.Update(budget);
            }
        }

    }
}