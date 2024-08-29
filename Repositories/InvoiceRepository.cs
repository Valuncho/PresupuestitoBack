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


        public override async Task<bool> Insert(Invoice newInvoice)
        {
            try
            {
                await base.Insert(newInvoice);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override async Task<bool> Update(Invoice updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}


