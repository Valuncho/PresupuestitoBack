using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<Invoice> GetByIdAsync(int id)
        {
            return await _invoiceRepository.GetById(c => c.IdInvoice == id);
        }

        public async Task<List<Invoice>> GetAllAsync(Expression<Func<Invoice, bool>>? filter = null)
        {
            return await _invoiceRepository.GetAll(filter);
        }

        public async Task<bool> DeleteAsync(int idInvoice)
        {
            return await _invoiceRepository.Delete(idInvoice);
        }

        public async Task<bool> SaveAsync(Invoice invoice)
        {
            return await _invoiceRepository.Insert(invoice);
        }

        public async Task<bool> UpdateAsync(Invoice invoice)
        {
            return await _invoiceRepository.Update(invoice);
        }
    }
}