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


        public override async Task<bool> Insert(InvoiceItem newInvoiceItem)
        {
            try
            {
                await base.Insert(newInvoiceItem);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(InvoiceItem updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}


