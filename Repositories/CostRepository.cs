using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class CostRepository : Repository<Cost>, ICostRepository
    {

        private readonly ApplicationDbContext context;

        public CostRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Cost cost)
        {
            await context.Costs.AddAsync(cost);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Cost cost)
        {
            context.Costs.Update(cost);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Cost> GetById(Expression<Func<Cost, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Cost>> GetAll(Expression<Func<Cost, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
