using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class ClientHistoryService
    {
        private readonly IClientHistoryRepository _clientHistoryRepository;

        public ClientHistoryService(IClientHistoryRepository clientHistoryRepository)
        {
            _clientHistoryRepository = clientHistoryRepository;
        }
        public async Task<ClientHistory> GetByIdAsync(int id)
        {
            return await _clientHistoryRepository.GetById(c => c.IdClientHistory == id);
        }

        public async Task<List<ClientHistory>> GetAllAsync(Expression<Func<ClientHistory, bool>>? filter = null)
        {
            return await _clientHistoryRepository.GetAll(filter);
        }

        public async Task<bool> DeleteAsync(int idClientHistory)
        {
            return await _clientHistoryRepository.Delete(idClientHistory);
        }

        public async Task<bool> SaveAsync(ClientHistory clientHistory)
        {
            return await _clientHistoryRepository.Insert(clientHistory);
        }

        public async Task<bool> UpdateAsync(ClientHistory clientHistory)
        {
            return await _clientHistoryRepository.Update(clientHistory);
        }
    }
}