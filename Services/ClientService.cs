using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly Mapper _mapper;

        public ClientService(IClientRepository clientRepository, Mapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper; 
        }
        public async Task<Client> GetByIdAsync(int id) 
        {
            var clientDto = await _clientRepository.GetById(c => c.IdClient == id);
            var client = _mapper.Map<Client>(clientDto);
            return client; 
        }

        public async Task<List<Client>> GetAllAsync(Expression<Func<Client, bool>>? filter = null) 
        {
            var clientDto = await _clientRepository.GetAll(filter);
            var clients = _mapper.Map<List<Client>>(clientDto);
            return clients; 
        }

        public async Task<bool> DeleteAsync(int idClient)
        {
            return await _clientRepository.Delete(idClient);
        }

        public async Task<bool> SaveAsync(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            return await _clientRepository.Insert(client);
        }

        public async Task<bool> UpdateAsync(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            return await _clientRepository.Update(client);
        }
    }
}