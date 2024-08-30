using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class SalaryService
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly Mapper _mapper;

        public SalaryService(ISalaryRepository salaryRepository, Mapper mapper)
        {
            _salaryRepository = salaryRepository;
            _mapper = mapper;
        }
        public async Task<Salary> GetByIdAsync(int id)
        {
            var salaryDto = await _salaryRepository.GetById(c => c.IdSalary == id);
            var salary = _mapper.Map<Salary>(salaryDto);
            return salary;
        }

        public async Task<List<Salary>> GetAllAsync(Expression<Func<Salary, bool>>? filter = null)
        {
            var salaryDto = await _salaryRepository.GetAll(filter);
            var salaries = _mapper.Map<List<Salary>>(salaryDto);
            return salaries;
        }

        public async Task<bool> DeleteAsync(int idSalary)
        {
            return await _salaryRepository.Delete(idSalary);
        }

        public async Task<bool> SaveAsync(SalaryDto salaryDto)
        {
            var salary = _mapper.Map<Salary>(salaryDto);
            return await _salaryRepository.Insert(salary);
        }

        public async Task<bool> UpdateAsync(SalaryDto salaryDto)
        {
            var salary = _mapper.Map<Salary>(salaryDto);
            return await _salaryRepository.Update(salary);
        }
    }
}
