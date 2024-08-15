using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [ApiController]
    [Route("api/[controller/category]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("/create")]
        public async Task<ActionResult<CategoryDto>> AddCategory(CategoryDto categoryDto)
        {
            /*
            var category = new Category()
            {
                CategoryName = categoryDto.CategoryName,
                CategoryModel = categoryDto.CategoryModel
            };
            context.Categories.Add(category);
            context.SaveChanges();
            return Ok(category);
            */

            var category = mapper.Map<Category>(categoryDto);
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return Ok(mapper.Map<CategoryDto>(category));
        }

        [HttpGet]
        [Route("/getAll")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            //return Ok(context.Categories.ToList());
            var categories = await Task.Run(() => context.Categories.ToList());
            return Ok(mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpGet]
        [Route("/getById")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            /*
            var category = context.Categories.Find(id);
            return category == null ? NotFound() : Ok(category);
            */
            var category = await context.Categories.FindAsync(id);
            return category == null ? NotFound() : Ok(mapper.Map<CategoryDto>(category));
        }

        [HttpPut]
        [Route("/update")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, CategoryDto categoryDto)
        {
            /*
            var category = context.Categories.Find(id);

            if (category != null)
            {
                category.CategoryName = categoryDto.CategoryName;
                category.CategoryModel = categoryDto.CategoryModel;
            }
            context.SaveChanges();
            return category == null ? NotFound() : Ok(category);
            */

            var category = await context.Categories.FindAsync(id);

            if(category != null)
            {
                mapper.Map(categoryDto, category);
            }
            await context.SaveChangesAsync();
            return category == null ? NotFound() : Ok(category);
        }
            
            

        
    }
}
