using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class SupplierHistoryRepository : Repository<SupplierHistory>, ISupplierHistoryRepository
    {
        public SupplierHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
