using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;

[ApiController]
[Route("api/[controller/CategoryController]")]
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
        var category = mapper.Map<Category>(categoryDto);
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        ActionResult<CategoryDto> result = Ok(mapper.Map<CategoryDto>(category));
        return result;
    }

    [HttpGet]
    [Route("/getAll")]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
    {
        var categories = await context.Categories.ToListAsync();
        var categoryDtos = mapper.Map<List<CategoryDto>>(categories);

        ActionResult<List<CategoryDto>> result = Ok(categoryDtos);
        return result;
    }

    [HttpGet]
    [Route("/getById")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
    {
        var category = await context.Categories.FindAsync(id);
        ActionResult<CategoryDto> result;

        if (category == null)
        {
            result = NotFound();
        }
        else
        {
            result = Ok(mapper.Map<CategoryDto>(category));
        }

        return result;
    }

    [HttpPut]
    [Route("/update")]
    public async Task<ActionResult<CategoryDto>> UpdateCategory(int id, CategoryDto categoryDto)
    {
        var category = await context.Categories.FindAsync(id);
        ActionResult<CategoryDto> result;

        if (category == null)
        {
            result = NotFound();
        }
        else
        {
            mapper.Map(categoryDto, category);
            await context.SaveChangesAsync();
            result = Ok(mapper.Map<CategoryDto>(category));
        }

        return result;
    }
}
