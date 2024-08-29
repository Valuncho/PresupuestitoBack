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


        public InvoiceItemController(InvoiceItemService invoiceItemService)
        {
            this.invoiceItemService = invoiceItemService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<InvoiceItemDto>>> GetInvoicesItems()
        {
            var invoicesItems = await invoiceItemService.GetAllAsync();
            return Ok(invoicesItems);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveInvoiceItem(InvoiceItemDto invoiceItemDto)
        {
            var result = await invoiceItemService.SaveAsync(invoiceItemDto);
            if (result)
            {
                return Ok("InvoiceItem guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el invoiceItem.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItemDto>> GetInvoiceItemById(int id)
        {
            var invoiceItem = await invoiceItemService.GetByIdAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            return Ok(invoiceItem);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateInvoiceItemById(int id, InvoiceItemDto requestDto)
        {
            requestDto.IdInvoiceItem = id; // Ensure the ID is set correctly for updating
            var result = await invoiceItemService.UpdateAsync(requestDto);
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