using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/EmployeeHistory")]
    public class EmployeeHistoryController : ControllerBase
    {
        private readonly EmployeeHistoryService employeeHistoryService;

        public EmployeeHistoryController(EmployeeHistoryService employeeHistoryService)
        {
            this.employeeHistoryService = employeeHistoryService;
        }

        [HttpPost]
        public async Task createEmployee(EmployeeHistoryDto employeeHistoryDto)
        {
            await employeeHistoryService.createEmployeeHistory(employeeHistoryDto);
        }

        [HttpPut("{id}")]
        public async Task updateEmployee(EmployeeHistoryDto employeeHistoryDto)
        {
            await employeeHistoryService.updateEmployeeHistory(employeeHistoryDto);
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDto> getEmployeeById(int id)
        {
            return await employeeHistoryService.getEmployeeHistoryById(id);
        }

        [HttpGet]
        public async Task<List<EmployeeDto>> getAllEmployee()
        {
            return await employeeHistoryService.getEmployeeHistorys();
        }
    }
}
