using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.DTOs;
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

    }
}


