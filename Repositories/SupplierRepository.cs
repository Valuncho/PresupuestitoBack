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

        public override async Task<Supplier> GetById(Expression<Func<Supplier, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Supplier>> GetAll(Expression<Func<Supplier, bool>>? filter = null)
        {
            return await context.Suppliers.Include(s => s.OPerson) // Incluir la entidad Person
            .ToListAsync();
        }

    }
}
