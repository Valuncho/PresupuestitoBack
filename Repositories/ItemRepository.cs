using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override async Task<bool> Update(Item updateService)
        {
            var Service = await _context.Items.FirstOrDefaultAsync(x => x.IdItem == updateService.IdItem);
            if (Service == null) { return false; }

            Service.OMaterial = updateService.OMaterial;
            Service.Quantity = updateService.Quantity;
            
            _context.Items.Update(Service);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var item = await _context.Items.Where(x => x.IdItem == id).FirstOrDefaultAsync();
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public override async Task<bool> Insert(Item newItem)
        {
            try
            {
                var personExisting = await _context.Items.FirstOrDefaultAsync(x => x.IdItem == newItem.IdItem);

                if (personExisting != null)
                {
                    return false;
                }

                _context.Items.Add(newItem);
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
