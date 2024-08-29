using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly Mapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, Mapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<Invoice> GetByIdAsync(int id)
        {
            var invoiceDto = await _invoiceRepository.GetById(c => c.IdInvoice == id);
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            return invoice;
        }

        public async Task<List<Invoice>> GetAllAsync(Expression<Func<Invoice, bool>>? filter = null)
        {
            var invoiceDto = await _invoiceRepository.GetAll(filter);
            var invoices = _mapper.Map<List<Invoice>>(invoiceDto);
            return invoices;
        }

        public async Task<bool> DeleteAsync(int idInvoice)
        {
            return await _invoiceRepository.Delete(idInvoice);
        }

        public async Task<bool> SaveAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            return await _invoiceRepository.Insert(invoice);
        }

        public async Task<bool> UpdateAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
            return await _invoiceRepository.Update(invoice);
        }
    }
}