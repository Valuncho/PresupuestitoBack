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
        public async Task<Budget> GetByIdAsync(int id) { return await _budgetRepository.GetById(b => b.IdBudget == id); }
        public async Task<List<Budget>> GetAllAsync(Expression<Func<Budget, bool>>? filter = null) { return await _budgetRepository.GetAll(filter); }

        internal async Task Delete(int idBudget)
        {
            throw new NotImplementedException();
        }
    }
}