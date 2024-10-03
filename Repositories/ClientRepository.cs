using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {

        private readonly ApplicationDbContext context;

        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Client client)
        {
            await context.Clients.AddAsync(client);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Client client)
        {
            context.Clients.Update(client);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Client> GetById(int id)
        {
            return await context.Clients.Include(o => o.OPerson)
                .Where(o => o.Status == true && o.PersonId == id).FirstAsync();
        }

        public override async Task<List<Client>> GetAll(Expression<Func<Client, bool>>? filter = null)
        {
            return await context.Clients.Include(c => c.OPerson) // Incluir la entidad Person
            .ToListAsync();
        }

    }
}


