using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class SupplierHistoryRepository : Repository<SupplierHistory>, ISupplierHistoryRepository
    {

        private readonly ApplicationDbContext context;

        public SupplierHistoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(SupplierHistory supplierHistory)
        {
            await context.SupplierHistories.AddAsync(supplierHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(SupplierHistory supplierHistory)
        {
            context.SupplierHistories.Update(supplierHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<SupplierHistory> GetById(Expression<Func<SupplierHistory, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<SupplierHistory>> GetAll(Expression<Func<SupplierHistory, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
