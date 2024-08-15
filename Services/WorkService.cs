using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class WorkService
    {
        private readonly IWorkRepository _workRepository;

        public WorkService(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }
        public async Task<Work> GetByIdAsync(int id) { return await _workRepository.GetById(p => p.IdWork == id); }
        public async Task<List<Work>> GetAllAsync(Expression<Func<Work, bool>>? filter = null) { return await _workRepository.GetAll(filter); }

        internal async Task Delete(int idWork)
        {
            throw new NotImplementedException();
        }
    }
}
