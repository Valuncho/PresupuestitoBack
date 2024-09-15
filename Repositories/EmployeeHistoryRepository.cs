using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class EmployeeHistoryRepository : Repository<EmployeeHistory>, IEmployeeHistoryRepository
    {

        private readonly ApplicationDbContext context;

        public EmployeeHistoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(EmployeeHistory employeeHistory)
        {
            await context.EmployeeHistories.AddAsync(employeeHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(EmployeeHistory employeeHistory)
        {
            context.EmployeeHistories.Update(employeeHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<EmployeeHistory> GetById(Expression<Func<EmployeeHistory, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<EmployeeHistory>> GetAll(Expression<Func<EmployeeHistory, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
