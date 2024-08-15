using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly InvoiceService _invoiceService;

        public InvoiceController(IMapper mapper, InvoiceService invoiceService)
        {
            _mapper = mapper;
            _invoiceService = invoiceService;
        }
        [HttpGet("{id}", Name = "GetInvoiceById")]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            /*if (id == 0)
            {
                return BadRequest();
            }*/

            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice != null)
            {
                return Ok(_mapper.Map<ClientDto>(invoice));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<InvoiceDto>>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return Ok(_mapper.Map<List<InvoiceDto>>(invoices));
        }
        [HttpDelete]
        public async Task<ActionResult<InvoiceDto>> Delete(int IdInvoice)
        {
            if (IdInvoice == 0)
            {
                return BadRequest();
            }
            else
            {
                await _invoiceService.Delete(IdInvoice);
                return NoContent();
            }
        }
    }
}