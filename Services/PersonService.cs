using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PresupuestitoBack.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;       
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Person> GetByIdAsync(int id){ return await _personRepository.GetById(p => p.IdPerson == id);}
        public async Task<List<Person>> GetAllAsync(Expression<Func<Person, bool>>? filter = null){ return await _personRepository.GetAll(filter);}

        internal async Task Delete(int idPerson)
        {
            throw new NotImplementedException();
        }
    }
}
