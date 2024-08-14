using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Client> GetByIdAsync(int id) { return await _clientRepository.GetById(p => p.IdClient == id); }
        public async Task<List<Client>> GetAllAsync(Expression<Func<Client, bool>>? filter = null) { return await _clientRepository.GetAll(filter); }

        internal async Task Delete(int idClient)
        {
            throw new NotImplementedException();
        }
    }
}