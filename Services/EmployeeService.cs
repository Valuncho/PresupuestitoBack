using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task CreateEmployee(EmployeeRequestDto employeeRequestDto)
        {
            var employee = mapper.Map<Employee>(employeeRequestDto);
            employee.Status = true;
            await employeeRepository.Insert(employee);
        }

        public async Task UpdateEmployee(int id, EmployeeRequestDto employeeRequestDto)
        {
            var existingEmployee = mapper.Map<Employee>(employeeRequestDto);
            if (existingEmployee == null) 
            {
                throw new KeyNotFoundException("El empleado no existe");
            }
            else
            {
                var employee = mapper.Map<Employee>(employeeRequestDto);
                await employeeRepository.Update(employee);
            }
        }

        public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeById(int id)
        {
            var employee = await employeeRepository.GetById(c => c.IdEmployee == id);
            if(employee == null)
            {
                throw new KeyNotFoundException("El empleado no existe");
            }
            else
            {
                return mapper.Map<EmployeeResponseDto>(employee);
            }           
        }

        public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllEmployees()
        {
            var employees = await employeeRepository.GetAll();
            if(employees == null)
            {
                throw new Exception("Empleados no encontrados");
            }
            else
            {
                return mapper.Map<List<EmployeeResponseDto>>(employees);
            }           
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await employeeRepository.GetById(c => c.IdEmployee == id);
            if (employee == null)
            {
                throw new KeyNotFoundException("El empleado no existe");
            }
            else
            {
                employee.Status = false;
                await employeeRepository.Update(employee);
            }
        }

    }
}
