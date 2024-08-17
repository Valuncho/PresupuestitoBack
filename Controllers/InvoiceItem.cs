using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]/InvoiceItem")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly InvoiceItemService _invoiceItemService;

        public InvoiceItemController(IMapper mapper, InvoiceItemService invoiceItemService)
        {
            _mapper = mapper;
            _invoiceItemService = invoiceItemService;
        }
        [HttpGet("{id}", Name = "GetInvoiceItemById")]
        public async Task<ActionResult<InvoiceItemDto>> GetInvoiceItem(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var invoiceItem = await _invoiceItemService.GetByIdAsync(id);
            if (invoiceItem != null)
            {
                return Ok(_mapper.Map<InvoiceItemDto>(invoiceItem));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<InvoiceItemDto>>> GetAllInvoicesItems()
        {
            var invoicesItems = await _invoiceItemService.GetAllAsync();
            return Ok(_mapper.Map<List<InvoiceItemDto>>(invoicesItems));
        }
        [HttpDelete]
        public async Task<ActionResult<InvoiceItemDto>> Delete(int IdInvoiceItem)
        {
            if (IdInvoiceItem == 0)
            {
                return BadRequest();
            }
            else
            {
                await _invoiceItemService.Delete(IdInvoiceItem);
                return NoContent();
            }
        }
    }
}