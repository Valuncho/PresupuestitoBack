using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {

        private readonly ApplicationDbContext context;

        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Supplier supplier)
        {
            await context.Suppliers.AddAsync(supplier);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Supplier supplier)
        {
            context.Suppliers.Update(supplier);
            await context.SaveChangesAsync();
            return true;
        }
        
        public override async Task<Supplier> GetById(int id)
        {
            return await context.Suppliers.Include(o => o.OPerson)
                .Where(o => o.Status == true && o.SupplierId == id).FirstAsync();
        }

        public override async Task<List<Supplier>> GetAll(Expression<Func<Supplier, bool>>? filter = null)
        {
            return await context.Suppliers.Include(s => s.OPerson) // Incluir la entidad Person
                .Where(o => o.Status == true)
                .ToListAsync();
        }

    }
}
