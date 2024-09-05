using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class FixedCostService
    {
        private readonly IFixedCostRepository _fixedCostRepository;
        private readonly Mapper _mapper;

        public FixedCostService(IFixedCostRepository fixedCostRepository, Mapper mapper)
        {
            _fixedCostRepository = fixedCostRepository;
            _mapper = mapper;
        }
        public async Task<FixedCost> GetByIdAsync(int id)
        {
            var fixedCostDto = await _fixedCostRepository.GetById(c => c.IdFixedCost == id);
            var fixedCost = _mapper.Map<FixedCost>(fixedCostDto);
            return fixedCost;
        }

        public async Task<List<FixedCost>> GetAllAsync(Expression<Func<FixedCost, bool>>? filter = null)
        {
            var fixedCostDto = await _fixedCostRepository.GetAll(filter);
            var fixedCosts = _mapper.Map<List<FixedCost>>(fixedCostDto);
            return fixedCosts;
        }

        public async Task<bool> DeleteAsync(int idFixedCost)
        {
            return await _fixedCostRepository.Delete(idFixedCost);
        }

        public async Task<bool> SaveAsync(FixedCostDto fixedCostDto)
        {
            var fixedCost = _mapper.Map<FixedCost>(fixedCostDto);
            return await _fixedCostRepository.Insert(fixedCost);
        }

        public async Task<bool> UpdateAsync(FixedCostDto fixedCostDto)
        {
            var fixedCost = _mapper.Map<FixedCost>(fixedCostDto);
            return await _fixedCostRepository.Update(fixedCost);
        }
    }
}
