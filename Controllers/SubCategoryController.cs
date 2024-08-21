using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;

[Route("api/[controller/SubCategoryController]")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public SubCategoryController(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpPost]
    [Route("/create")]
    public async Task<ActionResult<SubCategoryDto>> CreateSubCategory(SubCategoryDto subCategoryDto)
    {
        var subCategory = mapper.Map<SubCategory>(subCategoryDto);
        context.SubCategories.Add(subCategory);
        await context.SaveChangesAsync();

        ActionResult<SubCategoryDto> result = Ok(mapper.Map<SubCategoryDto>(subCategory));
        return result;
    }

    [HttpGet]
    [Route("/getAll")]
    public async Task<ActionResult<List<SubCategoryDto>>> GetAll()
    {
        var subCategories = await context.SubCategories.ToListAsync();
        var subCategoryDtos = mapper.Map<List<SubCategoryDto>>(subCategories);

        ActionResult<List<SubCategoryDto>> result = Ok(subCategoryDtos);
        return result;
    }

    [HttpGet]
    [Route("/getById")]
    public async Task<ActionResult<SubCategoryDto>> GetById(int id)
    {
        var subCategory = await context.SubCategories.FindAsync(id);
        ActionResult<SubCategoryDto> result;

        if (subCategory == null)
        {
            result = NotFound();
        }
        else
        {
            result = Ok(mapper.Map<SubCategoryDto>(subCategory));
        }

        return result;
    }

    [HttpPut]
    [Route("/update")]
    public async Task<ActionResult<SubCategoryDto>> UpdateSubCategory(int id, SubCategoryDto subCategoryDto)
    {
        var subCategory = await context.SubCategories.FindAsync(id);
        ActionResult<SubCategoryDto> result;

        if (subCategory == null)
        {
            result = NotFound();
        }
        else
        {
            mapper.Map(subCategoryDto, subCategory);
            await context.SaveChangesAsync();
            result = Ok(mapper.Map<SubCategoryDto>(subCategory));
        }

        return result;
    }
}
