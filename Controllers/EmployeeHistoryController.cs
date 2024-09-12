using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
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
        public async Task<ActionResult<EmployeeHistory>> GetEmployeeHistoryById(int id)
        {
            var employeeHistory = await employeeHistoryService.GetByIdAsync(id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return Ok(employeeHistory);
        }

        [HttpGet]
        public async Task<List<EmployeeHistoryDto>> getAllEmployee()
        {
            return await employeeHistoryService.getEmployeeHistorys();
        }
    }
}
