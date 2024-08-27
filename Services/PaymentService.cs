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
        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _paymentRepository.GetById(c => c.IdPayment == id);
        }

        public async Task<List<Payment>> GetAllAsync(Expression<Func<Payment, bool>>? filter = null)
        {
            return await _paymentRepository.GetAll(filter);
        }

        public async Task<bool> DeleteAsync(int idPayment)
        {
            return await _paymentRepository.Delete(idPayment);
        }

        public async Task<bool> SaveAsync(Payment payment)
        {
            return await _paymentRepository.Insert(payment);
        }

        public async Task<bool> UpdateAsync(Payment payment)
        {
            return await _paymentRepository.Update(payment);
        }
    }
}