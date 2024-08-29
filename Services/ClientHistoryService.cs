using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class ClientHistoryService
    {
        private readonly IClientHistoryRepository _clientHistoryRepository;
        private readonly Mapper _mapper;

        public ClientHistoryService(IClientHistoryRepository clientHistoryRepository, Mapper mapper)
        {
            _clientHistoryRepository = clientHistoryRepository;
            _mapper = mapper;
        }
        public async Task<ClientHistory> GetByIdAsync(int id)
        {
            var clientHistoryDto = await _clientHistoryRepository.GetById(c => c.IdClientHistory == id);
            var clientHistory = _mapper.Map<ClientHistory>(clientHistoryDto);
            return clientHistory;
        }

        public async Task<List<ClientHistory>> GetAllAsync(Expression<Func<ClientHistory, bool>>? filter = null)
        {
            var clientHistoryDto = await _clientHistoryRepository.GetAll(filter);
            var clientsHistorys = _mapper.Map<List<ClientHistory>>(clientHistoryDto);
            return clientsHistorys;
        }

        public async Task<bool> DeleteAsync(int idClientHistory)
        {
            return await _clientHistoryRepository.Delete(idClientHistory);
        }

        public async Task<bool> SaveAsync(ClientHistoryDto clientHistoryDto)
        {
            var clientHistory = _mapper.Map<ClientHistory>(clientHistoryDto);
            return await _clientHistoryRepository.Insert(clientHistory);
        }

        public async Task<bool> UpdateAsync(ClientHistoryDto clientHistoryDto)
        {
            var clientHistory = _mapper.Map<ClientHistory>(clientHistoryDto);
            return await _clientHistoryRepository.Update(clientHistory);
        }
    }
}