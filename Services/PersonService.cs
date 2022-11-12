namespace ColaAplication.Services;
using ColaAplication;
using ColaAplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PersonService : IPersonService
{
    PersonContext _context;

    public PersonService(PersonContext context)
    {
        _context = context; 
    }

    public IEnumerable<Person> Get()
    {
        return _context.People;
    }

    public async Task Save(Person person)
    {
        person.PersonId = Guid.NewGuid();
        await _context.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task Update (Guid id, Person person)
    {
        var ActualPerson = _context.People.Find(id);

        if (ActualPerson != null)
        {
            ActualPerson.Name = person.Name;
            ActualPerson.Cedula = person.Cedula;
            ActualPerson.Edad = person.Edad;
            ActualPerson.Profession = person.Profession;

            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var PersonToRemove = _context.People.Find(id);

        if (PersonToRemove != null)
        {
            _context.Remove(PersonToRemove);
            await _context.SaveChangesAsync();
        }
       

    }
}

public interface IPersonService
{
    IEnumerable<Person> Get();
    Task Save(Person person);
    Task Update(Guid id, Person person);
    Task Delete(Guid id);
}

