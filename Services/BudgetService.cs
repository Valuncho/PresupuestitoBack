using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class BudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        private readonly Mapper _mapper;

        public BudgetService(IBudgetRepository budgetRepository, Mapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }
        public async Task<Budget> GetByIdAsync(int id)
        {
            var budgetDto = await _budgetRepository.GetById(c => c.IdBudget == id);
            var budget = _mapper.Map<Budget>(budgetDto);
            return budget;
        }

        public async Task<List<Budget>> GetAllAsync(Expression<Func<Budget, bool>>? filter = null)
        {
            var budgetDto = await _budgetRepository.GetAll(filter);
            var budgets = _mapper.Map<List<Budget>>(budgetDto);
            return budgets;
        }

        public async Task<bool> DeleteAsync(int idBudget)
        {
            return await _budgetRepository.Delete(idBudget);
        }

        public async Task<bool> SaveAsync(BudgetDto budgetDto)
        {
            var budget = _mapper.Map<Budget>(budgetDto);
            return await _budgetRepository.Insert(budget);
        }

        public async Task<bool> UpdateAsync(BudgetDto budgetDto)
        {
            var budget = _mapper.Map<Budget>(budgetDto);
            return await _budgetRepository.Update(budget);  
        }
    }
}