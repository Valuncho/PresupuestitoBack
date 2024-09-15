using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class InvoiceItemRepository : Repository<InvoiceItem>, IInvoiceItemRepository
    {

        private readonly ApplicationDbContext context;

        public InvoiceItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(InvoiceItem invoiceItem)
        {
            await context.InvoiceItems.AddAsync(invoiceItem);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(InvoiceItem invoiceItem)
        {
            context.InvoiceItems.Update(invoiceItem);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<InvoiceItem> GetById(Expression<Func<InvoiceItem, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<InvoiceItem>> GetAll(Expression<Func<InvoiceItem, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
