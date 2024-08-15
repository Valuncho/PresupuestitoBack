using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<Payment> GetByIdAsync(int id) { return await _paymentRepository.GetById(p => p.IdPayment == id); }
        public async Task<List<Payment>> GetAllAsync(Expression<Func<Payment, bool>>? filter = null) { return await _paymentRepository.GetAll(filter); }

        internal async Task Delete(int idPayment)
        {
            throw new NotImplementedException();
        }
    }
}