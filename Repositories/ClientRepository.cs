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

        public override async Task<bool> Update(Client updateService)
        {
            var Service = await _context.Clients.FirstOrDefaultAsync(x => x.IdClient == updateService.IdClient);
            if (Service == null) { return false; }

            Service.IdPerson = updateService.IdPerson;
            
            _context.Clients.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var client = await _context.Clients.Where(x => x.IdClient == id).FirstOrDefaultAsync();
            if ( client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }

            return true;
        }

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
    }
}


