using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {


        public BudgetRepository(ApplicationDbContext context) : base(context)
        {
        }


        public override async Task<bool> Insert(Budget newBudget)
        {
            try
            {
                await base.Insert(newBudget);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(Budget updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}


