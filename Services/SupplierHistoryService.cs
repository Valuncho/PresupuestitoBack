using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class SupplierHistoryService
    {
        private readonly ISupplierHistoryRepository _supplierHistoryRepository;

        public SupplierHistoryService(ISupplierHistoryRepository supplierHistoryRepository)
        {
            _supplierHistoryRepository = supplierHistoryRepository;
        }
        public async Task<SupplierHistory> GetByIdAsync(int id) { return await _supplierHistoryRepository.GetById(p => p.IdSupplierHistory == id); }
        public async Task<List<SupplierHistory>> GetAllAsync(Expression<Func<SupplierHistory, bool>>? filter = null) { return await _supplierHistoryRepository.GetAll(filter); }

        internal async Task Delete(int idSupplierHistory)
        {
            throw new NotImplementedException();
        }
    }
}
