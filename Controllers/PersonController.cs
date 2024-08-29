using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PersonService _personService;

        public PersonController(IMapper mapper, PersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }
        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<ActionResult<PersonDto>> GetPerson(int id)
        {
            /*if (id == 0)
            {
                return BadRequest();
            }*/

            var person = await _personService.GetByIdAsync(id);
            if (person != null)
            {
                return Ok(_mapper.Map<PersonDto>(person));
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> GetAllPersons()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(_mapper.Map<List<PersonDto>>(persons));
        }
        [HttpDelete]
        public async Task<ActionResult<PersonDto>> Delete(int IdPerson)
        {
            if (IdPerson == 0) { return BadRequest();
            }
            else
            {
                await _personService.Delete(IdPerson);
                return NoContent();
            }       
        }
    }
}
