﻿using PresupuestitoBack.Models;
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
        public async Task<InvoiceItem> GetByIdAsync(int id)
        {
            return await _invoiceItemRepository.GetById(c => c.IdInvoiceItem == id);
        }

        public async Task<List<InvoiceItem>> GetAllAsync(Expression<Func<InvoiceItem, bool>>? filter = null)
        {
            return await _invoiceItemRepository.GetAll(filter);
        }

        public async Task<bool> DeleteAsync(int idInvoiceItem)
        {
            return await _invoiceItemRepository.Delete(idInvoiceItem);
        }

        public async Task<bool> SaveAsync(InvoiceItem invoiceItem)
        {
            return await _invoiceItemRepository.Insert(invoiceItem);
        }

        public async Task<bool> UpdateAsync(InvoiceItem invoiceItem)
        {
            return await _invoiceItemRepository.Update(invoiceItem);
        }
    }
}