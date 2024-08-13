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

        public override async Task<bool> Update(Budget updateService)
        {
            var Service = await _context.Budgets.FirstOrDefaultAsync(x => x.IdBudget == updateService.IdBudget);
            if (Service == null) { return false; }

            Service.Works = updateService.Works;
            Service.Cost = updateService.Cost;
            Service.DescriptionBudget = updateService.DescriptionBudget;
            Service.Payments = updateService.Payments;

            _context.Budgets.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var budget = await _context.Budgets.Where(x => x.IdBudget == id).FirstOrDefaultAsync();
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Budget newBudget)
        {
            try
            {
                var BudgetExisting = await _context.Budgets.FirstOrDefaultAsync(x => x.IdBudget == newBudget.IdBudget);

                if (BudgetExisting != null)
                {
                    return false;
                }

                _context.Budgets.Add(newBudget);
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


