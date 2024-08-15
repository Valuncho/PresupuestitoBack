using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Item> GetByIdAsync(int id) { return await _itemRepository.GetById(p => p.IdItem == id); }
        public async Task<List<Item>> GetAllAsync(Expression<Func<Item, bool>>? filter = null) { return await _itemRepository.GetAll(filter); }

        internal async Task Delete(int idItem)
        {
            throw new NotImplementedException();
        }
    }
}
