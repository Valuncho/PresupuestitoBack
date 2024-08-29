using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class CostRepository : Repository<Cost>, ICostRepository
    {
        public CostRepository(ApplicationDbContext context) : base(context)
        {
        }


        public override async Task<bool> Insert(Cost newCost)
        {
            try
            {
                await base.Insert(newCost);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(Cost updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
