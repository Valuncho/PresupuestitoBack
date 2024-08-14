using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {


        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Invoice updateService)
        {
            var Service = await _context.Invoices.FirstOrDefaultAsync(x => x.IdInvoice == updateService.IdInvoice);
            if (Service == null) { return false; }

            Service.Date = updateService.Date;
            Service.IsPaid = updateService.IsPaid;
            Service.IdSupplierHistory = updateService.IdSupplierHistory;
            Service.Payments = updateService.Payments;
            Service.InvoiceItems = updateService.InvoiceItems;


            _context.Invoices.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var invoice = await _context.Invoices.Where(x => x.IdInvoice == id).FirstOrDefaultAsync();
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Invoice newInvoice)
        {
            try
            {
                var invoiceExisting = await _context.Invoices.FirstOrDefaultAsync(x => x.IdInvoice == newInvoice.IdInvoice);

                if (invoiceExisting != null)
                {
                    return false;
                }

                _context.Invoices.Add(newInvoice);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}


