using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class InvoiceItemService
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository)
        {
            _invoiceItemRepository = invoiceItemRepository;
        }
        public async Task<InvoiceItem> GetByIdAsync(int id) { return await _invoiceItemRepository.GetById(i => i.IdInvoiceItem == id); }
        public async Task<List<InvoiceItem>> GetAllAsync(Expression<Func<InvoiceItem, bool>>? filter = null) { return await _invoiceItemRepository.GetAll(filter); }

        internal async Task Delete(int idInvoiceItem)
        {
            throw new NotImplementedException();
        }
    }
}