using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class ClientHistoryRepository : Repository<ClientHistory>, IClientHistoryRepository
    {


        public ClientHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(ClientHistory updateService)
        {
            var Service = await _context.ClientsHistorys.FirstOrDefaultAsync(x => x.IdClientHistory == updateService.IdClientHistory);
            if (Service == null) { return false; }

            Service.IdClient = updateService.IdClient;
            Service.Budgets = updateService.Budgets;

            _context.ClientsHistorys.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var client = await _context.ClientsHistorys.Where(x => x.IdClient == id).FirstOrDefaultAsync();
            if (client != null)
            {
                _context.ClientsHistorys.Remove(client);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(ClientHistory newClientHistory)
        {
            try
            {
                var clientHistoryExisting = await _context.ClientsHistorys.FirstOrDefaultAsync(x => x.IdClientHistory == newClientHistory.IdClientHistory);

                if (clientHistoryExisting != null)
                {
                    return false;
                }

                _context.ClientsHistorys.Add(newClientHistory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}


