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


        public override async Task<bool> Insert(ClientHistory newClientHistory)
        {
            try
            {
                await base.Insert(newClientHistory);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(ClientHistory updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}


