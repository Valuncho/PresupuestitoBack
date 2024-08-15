using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class CostService
    {
        private readonly ICostRepository _costRepository;

        public CostService(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }
        public async Task<Cost> GetByIdAsync(int id) { return await _costRepository.GetById(p => p.IdCost == id); }
        public async Task<List<Cost>> GetAllAsync(Expression<Func<Cost, bool>>? filter = null) { return await _costRepository.GetAll(filter); }

        internal async Task Delete(int idCost)
        {
            throw new NotImplementedException();
        }
    }
}
