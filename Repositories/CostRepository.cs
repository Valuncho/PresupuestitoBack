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
        public override async Task<bool> Update(Cost updateService)
        {
            var Service = await _context.Costs.FirstOrDefaultAsync(x => x.IdCost == updateService.IdCost);
            if (Service == null) { return false; }
            Service.CostValue = updateService.CostValue;
            Service.Description = updateService.Description;
            Service.TypeSerialized = updateService.TypeSerialized;
            _context.Costs.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var cost = await _context.Costs.Where(x => x.IdCost == id).FirstOrDefaultAsync();
            if (cost != null)
            {
                _context.Costs.Remove(cost);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Cost newCost)
        {
            try
            {
                var CostExisting = await _context.Costs.FirstOrDefaultAsync(x => x.IdCost == newCost.IdCost);

                if (CostExisting != null)
                {
                    return false;
                }

                _context.Costs.Add(newCost);
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
