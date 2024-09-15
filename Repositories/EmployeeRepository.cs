using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Employee> GetById(Expression<Func<Employee, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Employee>> GetAll(Expression<Func<Employee, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
