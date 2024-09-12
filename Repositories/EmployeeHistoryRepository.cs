using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

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
            await context.EmployeeHistorys.AddAsync(employeeHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(EmployeeHistory employeeHistory)
        {
            context.EmployeeHistorys.Update(employeeHistory);
            await context.SaveChangesAsync();
            return true;
        }
    
    }
}
