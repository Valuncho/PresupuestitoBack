using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;


namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller/SupplierHistoryController]")]
    [ApiController]
    public class SupplierHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public SupplierHistoryController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("/create")]
        public async Task<ActionResult<SupplierHistoryDto>> CreateSupplierHistory(SupplierHistoryDto supplierHistoryDto)
        {
            var supplierHistory = mapper.Map<SupplierHistory>(supplierHistoryDto);
            context.SupplierHistories.Add(supplierHistory);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<SupplierHistoryDto>(supplierHistory));
        }

        [HttpGet]
        [Route("/getAll")]
        public async Task<ActionResult<List<SupplierHistoryDto>>> GetAll()
        {
            var supplierHistories = await Task.Run(() => context.SupplierHistories.ToList());
            return Ok(mapper.Map<List<SupplierHistoryDto>>(supplierHistories));
        }

        [HttpGet]
        [Route("/getById")]
        public async Task<ActionResult<SupplierHistoryDto>> GetById(int id)
        {
            var supplierHistory = await context.SupplierHistories.FindAsync(id);
            return supplierHistory == null ? NotFound() : Ok(mapper.Map<SupplierHistoryDto>(supplierHistory));
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<SupplierHistoryDto>> UpdateSupplierHistory(int id, SupplierHistoryDto supplierHistoryDto)
        {
            var supplierHistory = await context.SupplierHistories.FindAsync(id);
            ActionResult<SupplierHistoryDto> result;

            if (supplierHistory == null)
            {
                result = NotFound();
            }
            else
            {
                mapper.Map(supplierHistoryDto, supplierHistory);
                await context.SaveChangesAsync();
                result = Ok(mapper.Map<SupplierHistoryDto>(supplierHistory));
            }

            return result;
        }
    }
}
