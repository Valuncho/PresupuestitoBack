using Microsoft.EntityFrameworkCore;
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

        public override async Task<ClientHistory> GetById(int id)
        {
            return await context.ClientHistories.Include(o => o.Oclient)
                .Where(o => o.Status == true && o.ClientId == id).FirstAsync();
        }

        public override async Task<List<ClientHistory>> GetAll(Expression<Func<ClientHistory, bool>>? filter = null)
        {
            return await context.ClientHistories.Include(c => c.Oclient) // Incluir la entidad Client
                .Where(o => o.Status == true)
                .ToListAsync();
        }

    }
}
