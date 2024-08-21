using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Models;

[Route("api/[controller/MaterialController]")]
[ApiController]
public class MaterialController : ControllerBase
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public MaterialController(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpPost]
    [Route("/create")]
    public async Task<ActionResult<MaterialDto>> AddMaterial(MaterialDto materialDto)
    {
        var material = mapper.Map<Material>(materialDto);
        context.Materials.Add(material);
        await context.SaveChangesAsync();

        ActionResult<MaterialDto> result = Ok(mapper.Map<MaterialDto>(material));
        return result;
    }

    [HttpGet]
    [Route("/getAll")]
    public async Task<ActionResult<List<MaterialDto>>> GetAllMaterials()
    {
        var materials = await context.Materials.ToListAsync();
        var materialDtos = mapper.Map<List<MaterialDto>>(materials);

        ActionResult<List<MaterialDto>> result = Ok(materialDtos);
        return result;
    }

    [HttpGet]
    [Route("/getById")]
    public async Task<ActionResult<MaterialDto>> GetById(int id)
    {
        var material = await context.Materials.FindAsync(id);
        ActionResult<MaterialDto> result;

        if (material == null)
        {
            result = NotFound();
        }
        else
        {
            result = Ok(mapper.Map<MaterialDto>(material));
        }

        return result;
    }

    [HttpPut]
    [Route("/update")]
    public async Task<ActionResult<MaterialDto>> UpdateMaterial(int id, MaterialDto materialDto)
    {
        var material = await context.Materials.FindAsync(id);
        ActionResult<MaterialDto> result;

        if (material == null)
        {
            result = NotFound();
        }
        else
        {
            mapper.Map(materialDto, material);
            await context.SaveChangesAsync();
            result = Ok(mapper.Map<MaterialDto>(material));
        }

        return result;
    }
}
