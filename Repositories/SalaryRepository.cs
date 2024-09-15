using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {

        private readonly ApplicationDbContext context;

        public SalaryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Salary salary)
        {
            await context.Salaries.AddAsync(salary);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Salary salary)
        {
            context.Salaries.Update(salary);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Salary> GetById(Expression<Func<Salary, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Salary>> GetAll(Expression<Func<Salary, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
