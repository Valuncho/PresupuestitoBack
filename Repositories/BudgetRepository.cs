using Microsoft.EntityFrameworkCore;
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

        public override async Task<Budget> GetById(int id)
        {
            return await context.Budgets.Include(o => o.OclientHistory)
                .Where(o => o.Status == true && o.ClientHistoryId == id).FirstAsync();
        }

        public override async Task<List<Budget>> GetAll(Expression<Func<Budget, bool>>? filter = null)
        {
            return await context.Budgets.Include(s => s.OclientHistory) // Incluir la entidad Person
            .ToListAsync();
        }

    }
}


