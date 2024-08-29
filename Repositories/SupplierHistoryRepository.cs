using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class SupplierHistoryRepository : Repository<SupplierHistory>, ISupplierHistoryRepository
    {
        public SupplierHistoryRepository(ApplicationDbContext context) : base(context) { }
        public override async Task<bool> Update(SupplierHistory updateSupplierHistory)
        {
            var SupplierHistory = await _context.SupplierHistories.FirstOrDefaultAsync(x => x.IdSupplierHistory == updateSupplierHistory.IdSupplierHistory);
            if (SupplierHistory == null) { return false; }

            SupplierHistory.OSupplier = updateSupplierHistory.OSupplier;
            SupplierHistory.OMaterial = updateSupplierHistory.OMaterial;
            SupplierHistory.QuantityMaterial = updateSupplierHistory.QuantityMaterial;
            SupplierHistory.PurchaseDateMaterial = updateSupplierHistory.PurchaseDateMaterial;
            SupplierHistory.PricePerUnitMaterial = updateSupplierHistory.PricePerUnitMaterial;
            SupplierHistory.PriceTotal = updateSupplierHistory.PriceTotal;
            _context.SupplierHistories.Update(SupplierHistory);
            await _context.SaveChangesAsync();
            return true;
        }
        public override async Task<bool> Delete(int id)
        {
            var supplierHistory = await _context.SupplierHistories.Where(x => x.IdSupplierHistory == id).FirstOrDefaultAsync();
            if(supplierHistory != null) 
            {
                _context.SupplierHistories.Remove(supplierHistory);
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
