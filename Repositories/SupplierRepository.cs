using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<bool> Update(Supplier updateSupplier)
        {
            var Supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.IdSupplier == updateSupplier.IdSupplier);
            if (Supplier == null) { return false; }

            Supplier.OPerson = updateSupplier.OPerson;
            _context.Suppliers.Update(Supplier);
            await _context.SaveChangesAsync();
            return true;
        }
        public override async Task<bool> Delete(int id)
        {
            var supplier = await _context.Suppliers.Where(x => x.IdSupplier == id).FirstOrDefaultAsync();
            if(supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
