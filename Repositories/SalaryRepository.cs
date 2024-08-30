using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {
        public SalaryRepository(ApplicationDbContext context) : base(context)
        {
        }


        public override async Task<bool> Insert(Salary newSalary)
        {
            try
            {
                await base.Insert(newSalary);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(Salary updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
