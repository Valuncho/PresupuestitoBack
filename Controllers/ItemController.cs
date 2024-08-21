using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
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
