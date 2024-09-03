using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService paymentService;

        public PaymentController(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        public async Task CreatePayment(PaymentDto paymentDto)
        {
            await paymentService.CreatePayment(paymentDto);
        }

        [HttpPut("{id}")]
        public async Task UpdatePaymentById(PaymentDto paymentDto)
        {
            await paymentService.UpdatePayment(paymentDto);
        }

        [HttpGet("{id}")]
        public async Task<PaymentDto> GetPaymentById(int id)
        {
            return await paymentService.GetPaymentById(id);
        }

        [HttpGet]
        public async Task<List<PaymentDto>> GetPayments()
        {
            return await paymentService.GetPayments();
        }

        


        


        
    }
}