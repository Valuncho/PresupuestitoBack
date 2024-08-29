using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class WorkService
    {
        private readonly IWorkRepository _workRepository;
        private readonly Mapper _mapper;

        public WorkService(IWorkRepository workRepository, Mapper mapper)
        {
            _workRepository = workRepository;
            _mapper = mapper;
        }
        public async Task<Work> GetByIdAsync(int id)
        {
            var workDto = await _workRepository.GetById(c => c.IdWork == id);
            var work = _mapper.Map<Work>(workDto);
            return work;
        }

        public async Task<List<Work>> GetAllAsync(Expression<Func<Work, bool>>? filter = null)
        {
            var workDto = await _workRepository.GetAll(filter);
            var works = _mapper.Map<List<Work>>(workDto);
            return works;
        }

        public async Task<bool> DeleteAsync(int idWork)
        {
            return await _workRepository.Delete(idWork);
        }

        public async Task<bool> SaveAsync(WorkDto workDto)
        {
            var work = _mapper.Map<Work>(workDto);
            return await _workRepository.Insert(work);
        }

        public async Task<bool> UpdateAsync(WorkDto workDto)
        {
            var work = _mapper.Map<Work>(workDto);
            return await _workRepository.Update(work);
        }
    }
}
