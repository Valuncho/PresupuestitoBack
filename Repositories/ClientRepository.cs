using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {


        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }


        public override async Task<bool> Insert(Client newClient)
        {
            try
            {
                await base.Insert(newClient);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public override async Task<bool> Update(Client updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }


        /*
        public override async Task<bool> Insert(Client newClient)
        {
            try
            {
                var clientExisting = await _context.Clients.FirstOrDefaultAsync(x => x.IdClient == newClient.IdClient);

                if (clientExisting != null)
                {
                    return false;
                }

                _context.Clients.Add(newClient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        */
        
    }
}


