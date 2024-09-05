using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IMapper mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }    
        
        public async Task CreatePayment(PaymentDto paymentDto)
        {
            var payment = mapper.Map<Payment>(paymentDto);
            await paymentRepository.Insert(payment);
        }

        public async Task UpdatePayment(PaymentDto paymentDto)
        {
            var existingPayment = await paymentRepository.GetById(p => p.PaymentId == paymentDto.PaymentId);
            if (existingPayment == null)
            {
                throw new KeyNotFoundException("El pago no se encuentra");
            }
            else
            {
                var payment = mapper.Map<Payment>(paymentDto);
                await paymentRepository.Update(payment);
            }
        }

        public async Task<PaymentDto> GetPaymentById(int id)
        {
            var payment = await paymentRepository.GetById(p => p.PaymentId == id);
            if(payment == null)
            {
                throw new KeyNotFoundException("El pago no fue encontrado");
            }
            else
            {
                return mapper.Map<PaymentDto>(payment);
            }
        }

        public async Task<List<PaymentDto>> GetPayments()
        {
            var payments = await paymentRepository.GetAll();
            return mapper.Map<List<PaymentDto>>(payments);
        }
    }
}