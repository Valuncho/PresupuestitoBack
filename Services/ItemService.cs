using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class ItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly IMapper mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

        public async Task CreateItem(ItemRequestDto itemRequestDto)
        {
            var item = mapper.Map<Item>(itemRequestDto);
            item.Status = true;
            await itemRepository.Insert(item);
        }

        public async Task UpdateItem(int id, ItemRequestDto itemRequestDto)
        {
            var existingItem = await itemRepository.GetById(i => i.IdItem == id);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("El ítem no existe.");
            }
            else
            {
                var item = mapper.Map<Item>(itemRequestDto);                
                await itemRepository.Update(item);
            }
        }

        public async Task<ActionResult<ItemResponseDto>> GetItemById(int id)
        {
            var item = await itemRepository.GetById(i => i.IdItem == id);
            if (item == null)
            {
                throw new KeyNotFoundException("El ítem no fue encontrado.");
            }
            else
            {
                return mapper.Map<ItemResponseDto>(item);
            }
        }

        public async Task<ActionResult<List<ItemResponseDto>>> GetAllItems()
        {
            var items = await itemRepository.GetAll();
            if (items == null)
            {
                throw new Exception("Ítems no encontrados.");
            }
            else
            {
                return mapper.Map<List<ItemResponseDto>>(items);
            }
        }

        public async Task DeleteItem(int id)
        {
            var item = await itemRepository.GetById(i => i.IdItem == id);
            if (item == null)
            {
                throw new KeyNotFoundException("El ítem no fue encontrado.");
            }
            else
            {
                item.Status = false;
                await itemRepository.Update(item);
            }
        }

    }
}
