using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using PersonInfoSystems.Models;
using PersonInfoSystems.Contexts;
using PersonInfoSystems.Repositories;

namespace PersonInfoSystems.Repositories;

public class PersonRepository : ICRUDRepository<PersonEntity>
{
    private readonly PersonInfoSystemsDbContext _context;
    public PersonRepository(PersonInfoSystemsDbContext context)
    {
        this._context = context;
    }
    public async Task<PersonEntity> Add(PersonEntity person)
    {
        try
        {
            this._context.Persons.Add(person);
            await this._context.SaveChangesAsync();
            return person;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<PersonEntity>> GetAll()
    {
        try
        {
            return await this._context.Persons.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<PersonEntity?> GetById(int id)
    {
        try
        {
            return await this._context.Persons.FindAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    
    public async Task Update(PersonEntity person)
    {
        try
        {
            this._context.Persons.Update(person);
            await this._context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
        }
    }

    public async Task<bool> DeleteById(int id)
    {
        try
        {
            var deletePerson =await this._context.Persons.FindAsync(id);
            if(deletePerson == null)
            {
                return false;
            }
            this._context.Persons.Remove(deletePerson);
            await this._context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }
}