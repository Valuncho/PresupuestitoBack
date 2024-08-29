using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/invoiceItem")]
    public class InvoiceItemController : ControllerBase
    {


        private readonly InvoiceItemService invoiceItemService;
        private readonly IMapper mapper;

        public InvoiceItemController(InvoiceItemService invoiceItemService, IMapper mapper)
        {
            this.invoiceItemService = invoiceItemService;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<InvoiceItemDto>>> GetInvoicesItems()
        {
            var invoicesItems = await invoiceItemService.GetAllAsync();
            var invoicesItemsDto = mapper.Map<List<InvoiceItemDto>>(invoicesItems);
            return Ok(invoicesItemsDto);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveInvoiceItem( InvoiceItemDto invoiceItemDto)
        {
            var invoiceItem = mapper.Map<InvoiceItem>(invoiceItemDto);
            var result = await invoiceItemService.SaveAsync(invoiceItem);
            if (result)
            {
                return Ok("InvoiceItem guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el InvoiceItem.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItemDto>> GetInvoiceItemById(int id)
        {
            var invoiceItem = await invoiceItemService.GetByIdAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            var invoiceItemDto = mapper.Map<InvoiceItemDto>(invoiceItem);
            return Ok(invoiceItemDto);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateInvoiceItemById(int id, InvoiceItemDto requestDto)
        {
            var invoiceItem = mapper.Map<InvoiceItem>(requestDto);
            invoiceItem.IdInvoiceItem = id; // Ensure the ID is set correctly for updating
            var result = await invoiceItemService.UpdateAsync(invoiceItem);
            if (result)
            {
                return Ok("InvoiceItem actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el InvoiceItem.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteInvoiceItemById(int id)
        {
            try
            {
                var result = await invoiceItemService.DeleteAsync(id);
                if (result)
                {
                    return Ok("Registro eliminado :)");
                }
                return BadRequest("No se pudo eliminar el registro.");
            }
            catch (Exception ex)
            {
                return BadRequest($"No se pudo eliminar el registro. El error es: {ex.Message}");
            }
        }
    }
}