using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class FixedCostRepository : Repository<FixedCost>, IFixedCostRepository
    {
        public FixedCostRepository(ApplicationDbContext context) : base(context)
        {
        }


        public override async Task<bool> Insert(FixedCost newFixedCost)
        {
            try
            {
                await base.Insert(newFixedCost);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(FixedCost updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
