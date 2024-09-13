using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {

        private readonly ApplicationDbContext context;

        public ItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Item item)
        {
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Item> GetById(Expression<Func<Item, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Item>> GetAll(Expression<Func<Item, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

    }
}
