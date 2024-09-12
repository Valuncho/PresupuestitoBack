using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
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

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employeeDto = await employeeRepository.GetById(c => c.IdEmployee == id);
            var employee = mapper.Map<Employee>(employeeDto);
            return employee;
        }

        public async Task<List<EmployeeDto>> getEmployees()
        {
            var employees = await employeeRepository.GetAll();
            return mapper.Map<List<EmployeeDto>>(employees);
        }
    }
}
