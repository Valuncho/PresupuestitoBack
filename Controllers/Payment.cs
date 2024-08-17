using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PaymentService _paymentService;

        public PaymentController(IMapper mapper, PaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }
        [HttpGet("{id}", Name = "GetPaymentById")]
        public async Task<ActionResult<PaymentDto>> GetPayment(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var payment = await _paymentService.GetByIdAsync(id);
            if (payment != null)
            {
                return Ok(_mapper.Map<PaymentDto>(payment));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<PaymentDto>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(_mapper.Map<List<PaymentDto>>(payments));
        }
        [HttpDelete]
        public async Task<ActionResult<PaymentDto>> Delete(int IdPayment)
        {
            if (IdPayment == 0)
            {
                return BadRequest();
            }
            else
            {
                await _paymentService.Delete(IdPayment);
                return NoContent();
            }
        }
    }
}