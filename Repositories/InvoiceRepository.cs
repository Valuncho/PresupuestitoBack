using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {

        private readonly ApplicationDbContext context;

        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Invoice invoice)
        {
            await context.Invoices.AddAsync(invoice);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Invoice invoice)
        {
            context.Invoices.Update(invoice);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Invoice> GetById(int id)
        {
            return await context.Invoices.Where(invoice => invoice.Status == true && invoice.InvoiceId == id)
                .Include(invoice => invoice.OSupplier)
                .Include(invoice => invoice.InvoiceItems.Where(material => material.OMaterial.Status == true))
                .FirstAsync();
        }

        public override async Task<List<Invoice>> GetAll(Expression<Func<Invoice, bool>>? filter = null)
        {
            return await context.Invoices.Include(c => c.InvoiceItems)
                .Include(e => e.OSupplier)
                .Include(invoice => invoice.InvoiceItems.Where(material => material.OMaterial.Status == true))
                .Where(o => o.Status == true)
                .ToListAsync();
        }

        public async Task<List<Invoice>> GetInvoicesBySupplierId(int SupplierId)
        {
            return await context.Invoices
                                        .Where(invoice => invoice.Status == true && invoice.OSupplier.SupplierId == SupplierId)
                                        .Include(invoice => invoice.OSupplier)
                                        .Include(invoice => invoice.InvoiceItems)
                                        .ThenInclude(invoiceItem => invoiceItem.OMaterial)
                                        .ToListAsync();
        }

    }
}
