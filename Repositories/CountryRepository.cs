using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PersonInfoSystems.Models;
using PersonInfoSystems.Contexts;

namespace PersonInfoSystems.Repositories;

public class CountryRepository : ICRUDRepository<CountryEntity>
{
    private readonly PersonInfoSystemsDbContext _context;

    public CountryRepository(PersonInfoSystemsDbContext context)
    {
        this._context = context;
    }
    public async Task<CountryEntity> Add(CountryEntity country)
    {
        try
        {
            this._context.Countries.Add(country);
            await this._context.SaveChangesAsync();
            return country;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<CountryEntity>> GetAll()
    {
        try
        {
            return await this._context.Countries.ToListAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<CountryEntity?> GetById(int id)
    {
        try
        {
            return await this._context.Countries.FindAsync(id);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task Update(CountryEntity country)
    {
        try
        {
            this._context.Countries.Update(country);
            await this._context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    
    public async Task<bool> DeleteById(int id)
    {
        try
        {
            var deleteCountry = await this._context.Countries.FindAsync(id);
            if(deleteCountry == null)
            {
                return false;
            }
            this._context.Countries.Remove(deleteCountry);
            await this._context.SaveChangesAsync();
            return true;

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}