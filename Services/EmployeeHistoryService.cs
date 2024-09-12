using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class EmployeeHistoryService
    {
        private readonly IEmployeeHistoryRepository employeeHistoryRepository;
        private readonly IMapper mapper;

        public EmployeeHistoryService(IEmployeeHistoryRepository employeeHistoryRepository, Mapper mapper)
        {
            this.employeeHistoryRepository = employeeHistoryRepository;
            this.mapper = mapper;
        }

        public async Task createEmployeeHistory(EmployeeHistoryDto employeeHistoryDto)
        {
            var employeeHistory = mapper.Map<EmployeeHistory>(employeeHistoryDto);
            await employeeHistoryRepository.Insert(employeeHistory);
        }

        public async Task updateEmployeeHistory(EmployeeHistoryDto employeeHistoryDto)
        {
            var employeeHistory = mapper.Map<EmployeeHistory>(employeeHistoryDto);
            await employeeHistoryRepository.Update(employeeHistory);
        }

        public async Task<EmployeeHistory> GetByIdAsync(int id)
        {
            var employeeHistoryDto = await employeeHistoryRepository.GetById(c => c.IdEmployeeHistory == id);
            var employeeHistory = mapper.Map<EmployeeHistory>(employeeHistoryDto);
            return employeeHistory;
        }

        public async Task<List<EmployeeHistoryDto>> getEmployeeHistorys()
        {
            var employeesHistory = await employeeHistoryRepository.GetAll();
            return mapper.Map<List<EmployeeHistoryDto>>(employeesHistory);
        }
    }
}
