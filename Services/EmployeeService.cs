using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly Mapper mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, Mapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task createEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            await employeeRepository.Insert(employee);
        }

        public async Task updateEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            await employeeRepository.Update(employee);
        }

        public async Task<EmployeeDto> getEmployeeById(int id)
        {
            var employee = await employeeRepository.GetById(id);
            return mapper.Map<EmployeeDto>(employee);
        }

        public async Task<List<EmployeeDto>> getEmployees()
        {
            var employees = await employeeRepository.GetAll();
            return mapper.Map<List<EmployeeDto>>(employees);
        }
    }
}
