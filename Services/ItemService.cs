using AutoMapper;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepositories;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly Mapper _mapper;

        public ItemService(IItemRepository itemRepository, Mapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<Item> GetByIdAsync(int id) 
        {
            var itemDto = await _itemRepository.GetById(c => c.IdItem == id);
            var item = _mapper.Map<Item>(itemDto);
            return item;
        }
        public async Task<List<Item>> GetAllAsync(Expression<Func<Item, bool>>? filter = null)
        {
            var itemDto = await _itemRepository.GetAll(filter);
            var items = _mapper.Map<List<Item>>(itemDto);
            return items; 
        }
        internal async Task<bool> DeleteAsync(int idItem)
        {
            return await _itemRepository.Delete(idItem);
        }
        public async Task<bool> SaveAsync (ItemDao itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            return await _itemRepository.Insert(item);
        }

        public async Task<bool> UpdateAsync(ItemDao itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            return await _itemRepository.Update(item);
        }

    }
}
