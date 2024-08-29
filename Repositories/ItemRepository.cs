using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Net;

namespace PresupuestitoBack.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override async Task<bool> Update(Item updateService)
        {
            return await base.Update(updateService);
        }

        public override async Task<bool> Delete(int id)
        {
            return await base.Delete(id);

        }

        public override async Task<bool> Insert(Item newItem)
        {
            try
            {
                await base.Insert(newItem);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
