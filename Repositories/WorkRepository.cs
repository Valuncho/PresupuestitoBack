using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {

        private readonly ApplicationDbContext context;

        public WorkRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Work work)
        {
            await context.Works.AddAsync(work);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Work work)
        {
            context.Works.Update(work);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Work> GetById(Expression<Func<Work, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Work>> GetAll(Expression<Func<Work, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
