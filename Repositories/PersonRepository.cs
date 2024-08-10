using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {

    
    public PersonRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<bool> Update(Person updateService)
    {
        var Service = await _context.Persons.FirstOrDefaultAsync(x => x.IdPerson == updateService.IdPerson);
        if (Service == null) { return false; }

        Service.Name = updateService.Name;
        Service.LastName = updateService.LastName;
        Service.Address = updateService.Address;
        Service.PhoneNumber = updateService.PhoneNumber;
        Service.Email = updateService.Email;
        Service.DNI = updateService.DNI;
        Service.CUIT = updateService.CUIT;
        _context.Persons.Update(Service);
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


