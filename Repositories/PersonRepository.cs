using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {

    
    public PersonRepository(ApplicationDbContext context) : base(context){}

    public override async Task<bool> Update(Person updatePerson)
    {
        var Person = await _context.Persons.FirstOrDefaultAsync(x => x.IdPerson == updatePerson.IdPerson);
        if (Person == null) { return false; }

        Person.Name = updatePerson.Name;
        Person.LastName = updatePerson.LastName;
        Person.Address = updatePerson.Address;
        Person.PhoneNumber = updatePerson.PhoneNumber;
        Person.Email = updatePerson.Email;
        Person.DNI = updatePerson.DNI;
        Person.CUIT = updatePerson.CUIT;
        _context.Persons.Update(Person);
        await _context.SaveChangesAsync();
        return true;
    }

    public override async Task<bool> Delete(int id)
    {
        var person = await _context.Persons.Where(x => x.IdPerson == id).FirstOrDefaultAsync();
        if (person != null)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        return true;
    }

    public override async Task<bool> Insert(Person newPerson)
    {
        try
        {
            var personExisting = await _context.Persons.FirstOrDefaultAsync(x => x.IdPerson == newPerson.IdPerson);

            if (personExisting != null)
            {
                return false;
            }

            _context.Persons.Add(newPerson);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
  }
}


