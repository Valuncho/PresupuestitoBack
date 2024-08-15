using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
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
        public async Task<Invoice> GetByIdAsync(int id) { return await _invoiceRepository.GetById(i => i.IdInvoice == id); }
        public async Task<List<Invoice>> GetAllAsync(Expression<Func<Invoice, bool>>? filter = null) { return await _invoiceRepository.GetAll(filter); }

        internal async Task Delete(int idInvoice)
        {
            throw new NotImplementedException();
        }
    }
}