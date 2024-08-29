using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ItemService _itemService;

        public ItemController(IMapper mapper, ItemService itemService)
        {
            _mapper = mapper;
            _itemService = itemService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> SaveItem(ItemDao itemDAO)
        {
            var item = _mapper.Map<Item>(itemDAO);
            var result = await _itemService.SaveAsync(item);
            if (result)
            {
                return Ok("Item Guardado Correctamente");
            }
            return BadRequest("No se pudo cargar el Item");
        }

        [HttpGet("{id}", Name = "GetItemById")]
        public async Task<ActionResult<ItemDao>> GetItem(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var item = await _itemService.GetByIdAsync(id);
            if (item != null)
            {
                return Ok(_mapper.Map<ItemDao>(item));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<ItemDao>>> GetAllItems()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(_mapper.Map<List<ItemDao>>(items));
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateItemById(int id, ItemDao itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            item.IdItem = id;
            var result = await _itemService.UpdateAsync(item);
            if (result)
            {
                return Ok("Item Actualizado");
            }
            return BadRequest("No se puso actualizar el Item");
        }

        [HttpDelete]
        public async Task<ActionResult<ItemDao>> Delete(int IdItem)
        {
            if (IdItem == 0)
            {
                return BadRequest();
            }
            else
            {
                await _itemService.Delete(IdItem);
                return NoContent();
            }
        }
    }
}
