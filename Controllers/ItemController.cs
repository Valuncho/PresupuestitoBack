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
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            this._itemService = itemService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> SaveItem(ItemDao itemDto)
        {
            var result = await _itemService.SaveAsync(itemDto);
            if (result)
            {
                return Ok("Item guardado exitosamente.");
            }
            return BadRequest("No se pudo guardar el item.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDao>> GetItemById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        [HttpGet("getAll")]
        public async Task<ActionResult<List<ItemDao>>> GetAllItems()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateItemById(int id, ItemDao itemDto)
        {
            itemDto.IdItem = id; // Ensure the ID is set correctly for updating
            var result = await _itemService.UpdateAsync(itemDto);
            if (result)
            {
                return Ok("Item actualizado exitosamente.");
            }
            return BadRequest("No se pudo actualizar el item.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteItemById(int Id)
        {
            try
            {
                var result = await _itemService.DeleteAsync(Id);
                if (result)
                {
                    return Ok("Registro eliminado :)");
                }
                return BadRequest("No se pudo eliminar el registro.");
            }
            catch (Exception ex)
            {
                return BadRequest($"No se pudo eliminar el registro. El error es: {ex.Message}");
            }
        }
    }
}
