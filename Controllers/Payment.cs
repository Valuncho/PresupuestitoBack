using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.DTOs.RequestDTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {


        private readonly PaymentService paymentService;
        private readonly IMapper mapper;

        public PaymentController(PaymentService paymentService, IMapper mapper)
        {
            this.paymentService = paymentService;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<PaymentDto>>> GetPayments()
        {
            var payments = await paymentService.GetAllAsync();
            var paymentsDto = mapper.Map<List<PaymentDto>>(payments);
            return Ok(paymentsDto);
        }


        [HttpPost("new")]
        public async Task<ActionResult> SavePayment( PaymentDto paymentDto)
        {
            var payment = mapper.Map<Payment>(paymentDto);
            var result = await paymentService.SaveAsync(payment);
            if (result)
            {
                return Ok("Payment guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el Payment.");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(int id)
        {
            var payment = await paymentService.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = mapper.Map<PaymentDto>(payment);
            return Ok(paymentDto);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdatePaymentById(int id, PaymentDto requestDto)
        {
            var payment = mapper.Map<Payment>(requestDto);
            payment.IdPayment = id; // Ensure the ID is set correctly for updating
            var result = await paymentService.UpdateAsync(payment);
            if (result)
            {
                return Ok("Payment actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el Payment.");
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeletePaymentById(int id)
        {
            try
            {
                var result = await paymentService.DeleteAsync(id);
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