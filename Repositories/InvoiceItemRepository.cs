using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class InvoiceItemRepository : Repository<InvoiceItem>, IInvoiceItemRepository
    {


        public InvoiceItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(InvoiceItem updateService)
        {
            var Service = await _context.InvoicesItems.FirstOrDefaultAsync(x => x.IdInvoiceItem == updateService.IdInvoiceItem);
            if (Service == null) { return false; }

            Service.IdMaterial = updateService.IdMaterial;
            Service.Quantity = updateService.Quantity;
            Service.Price = updateService.Price;



            _context.InvoicesItems.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var invoiceItem = await _context.InvoicesItems.Where(x => x.IdInvoiceItem == id).FirstOrDefaultAsync();
            if (invoiceItem != null)
            {
                _context.InvoicesItems.Remove(invoiceItem);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(InvoiceItem newInvoiceItem)
        {
            try
            {
                var invoiceItemExisting = await _context.InvoicesItems.FirstOrDefaultAsync(x => x.IdInvoiceItem == newInvoiceItem.IdInvoiceItem);

                if (invoiceItemExisting != null)
                {
                    return false;
                }

                _context.InvoicesItems.Add(newInvoiceItem);
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


