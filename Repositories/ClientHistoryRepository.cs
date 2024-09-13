using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class ClientHistoryRepository : Repository<ClientHistory>, IClientHistoryRepository
    {
        private readonly ApplicationDbContext context;

        public ClientHistoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(ClientHistory clientHistory)
        {
            await context.ClientHistories.AddAsync(clientHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(ClientHistory clientHistory)
        {
            context.ClientHistories.Update(clientHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<ClientHistory?> GetById(Expression<Func<ClientHistory, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<ClientHistory>> GetAll(Expression<Func<ClientHistory, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
