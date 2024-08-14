using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<Supplier> GetByIdAsync(int id) { return await _supplierRepository.GetById(p => p.IdSupplier == id); }
        public async Task<List<Supplier>> GetAllAsync(Expression<Func<Supplier, bool>>? filter = null) { return await _supplierRepository.GetAll(filter); }

        internal async Task Delete(int idSupplier)
        {
            throw new NotImplementedException();
        }
    }
}
