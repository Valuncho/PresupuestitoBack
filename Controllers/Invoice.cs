using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : ControllerBase
    {


        private readonly InvoiceService invoiceService;


        public InvoiceController(InvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<InvoiceDto>>> GetInvoices()
        {
            var invoices = await invoiceService.GetAllAsync();
            return Ok(invoices);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SaveInvoice(InvoiceDto invoiceDto)
        {
            var result = await invoiceService.SaveAsync(invoiceDto);
            if (result)
            {
                return Ok("Cliente guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el cliente.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoiceById(int id)
        {
            var invoice = await invoiceService.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateInvoiceById(int id, InvoiceDto requestDto)
        {
            requestDto.IdInvoice = id; // Ensure the ID is set correctly for updating
            var result = await invoiceService.UpdateAsync(requestDto);
            if (result)
            {
                return Ok("Invoice actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el Invoice.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteInvoiceById(int id)
        {
            try
            {
                var result = await invoiceService.DeleteAsync(id);
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