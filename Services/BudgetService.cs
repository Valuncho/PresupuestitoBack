using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class BudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        public async Task<Budget> GetByIdAsync(int id)
        {
            return await _budgetRepository.GetById(b => b.IdBudget == id);
        }

        public async Task<List<Budget>> GetAllAsync(Expression<Func<Budget, bool>>? filter = null)
        {
            return await _budgetRepository.GetAll(filter);
        }

        public async Task<bool> DeleteAsync(int idBudget)
        {
            return await _budgetRepository.Delete(idBudget);
        }

        public async Task<bool> SaveAsync(Budget budget)
        {
            return await _budgetRepository.Insert(budget);
        }

        public async Task<bool> UpdateAsync(Budget budget)
        {
            return await _budgetRepository.Update(budget);
        }
    }
}