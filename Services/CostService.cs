using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class CostService
    {
        private readonly ICostRepository _costRepository;
        private readonly Mapper _mapper;

        public CostService(ICostRepository costRepository, Mapper mapper)
        {
            _costRepository = costRepository;
            _mapper = mapper;
        }
        public async Task<Cost> GetByIdAsync(int id)
        {
            var costDto = await _costRepository.GetById(c => c.IdCost == id);
            var cost = _mapper.Map<Cost>(costDto);
            return cost;
        }

        public async Task<List<Cost>> GetAllAsync(Expression<Func<Cost, bool>>? filter = null)
        {
            var costDto = await _costRepository.GetAll(filter);
            var costs = _mapper.Map<List<Cost>>(costDto);
            return costs;
        }

        public async Task<bool> DeleteAsync(int idCost)
        {
            return await _costRepository.Delete(idCost);
        }

        public async Task<bool> SaveAsync(CostDto costDto)
        {
            var cost = _mapper.Map<Cost>(costDto);
            return await _costRepository.Insert(cost);
        }

        public async Task<bool> UpdateAsync(CostDto costDto)
        {
            var cost = _mapper.Map<Cost>(costDto);
            return await _costRepository.Update(cost);
        }
    }
}
