using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class FixedCostRepository : Repository<FixedCost>, IFixedCostRepository
    {

        private readonly ApplicationDbContext context;

        public FixedCostRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(FixedCost fixedCost)
        {
            await context.FixedCosts.AddAsync(fixedCost);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(FixedCost fixedCost)
        {
            context.FixedCosts.Update(fixedCost);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<FixedCost> GetById(Expression<Func<FixedCost, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<FixedCost>> GetAll(Expression<Func<FixedCost, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
