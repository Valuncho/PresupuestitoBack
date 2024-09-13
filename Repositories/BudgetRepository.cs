using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {
        private readonly ApplicationDbContext context;

        public BudgetRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Budget budget)
        {
            await context.Budgets.AddAsync(budget);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Budget budget)
        {
            context.Budgets.Update(budget);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Budget?> GetById(Expression<Func<Budget, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Budget>> GetAll(Expression<Func<Budget, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}


