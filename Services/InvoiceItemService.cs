using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class InvoiceItemService
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly Mapper _mapper;

        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository, Mapper mapper)
        {
            _invoiceItemRepository = invoiceItemRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceItem> GetByIdAsync(int id)
        {
            var invoiceItemDto = await _invoiceItemRepository.GetById(c => c.IdInvoiceItem == id);
            var invoiceItem = _mapper.Map<InvoiceItem>(invoiceItemDto);
            return invoiceItem;
        }

        public async Task<List<InvoiceItem>> GetAllAsync(Expression<Func<InvoiceItem, bool>>? filter = null)
        {
            var invoiceItemDto = await _invoiceItemRepository.GetAll(filter);
            var invoicesItems = _mapper.Map<List<InvoiceItem>>(invoiceItemDto);
            return invoicesItems;
        }

        public async Task<bool> DeleteAsync(int idInvoiceItem)
        {
            return await _invoiceItemRepository.Delete(idInvoiceItem);
        }

        public async Task<bool> SaveAsync(InvoiceItemDto invoiceItemDto)
        {
            var invoiceItem = _mapper.Map<InvoiceItem>(invoiceItemDto);
            return await _invoiceItemRepository.Insert(invoiceItem);
        }

        public async Task<bool> UpdateAsync(InvoiceItemDto invoiceItemDto)
        {
            var invoiceItem = _mapper.Map<InvoiceItem>(invoiceItemDto);
            return await _invoiceItemRepository.Update(invoiceItem);
        }
    }
}