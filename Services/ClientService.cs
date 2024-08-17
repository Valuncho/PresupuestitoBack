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
        public async Task<Client> GetByIdAsync(int id) 
        { 
            return await _clientRepository.GetById(c => c.IdClient == id); 
        }

        public async Task<List<Client>> GetAllAsync(Expression<Func<Client, bool>>? filter = null) 
        { 
            return await _clientRepository.GetAll(filter); 
        }

        public async Task<bool> DeleteAsync(int idClient)
        {
            return await _clientRepository.Delete(idClient);
        }

        public async Task<bool> SaveAsync(Client client)
        {
            return await _clientRepository.Insert(client);
        }

        public async Task<bool> UpdateAsync(Client client)
        {
            return await _clientRepository.Update(client);
        }
    }
}