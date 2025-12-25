using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using PersonInfoSystems.Models;
using PersonInfoSystems.Contexts;
using System.Threading.Tasks;

namespace PersonInfoSystems.Repositories;

public class CityRepository : ICRUDRepository<CityEntity>
{
    private readonly PersonInfoSystemsDbContext _context;

    public CityRepository(PersonInfoSystemsDbContext context)
    {
        this._context = context;
    }

    public async Task<CityEntity> Add(CityEntity city)
    {
        try
        {
            this._context.Cities.Add(city);
            await this._context.SaveChangesAsync();
            return city;
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<CityEntity>> GetAll()
    {
        try
        {
            return await this._context.Cities.ToListAsync();
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<CityEntity?> GetById(int id)
    {
        try
        {
            return await this._context.Cities.FindAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task Update(CityEntity city)
    {
        try
        {
            this._context.Cities.Update(city);
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
            var deleteCity = await this._context.Cities.FindAsync(id);
            if (deleteCity == null)
            {
                return false;
            }
            this._context.Remove(deleteCity);
            await this._context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }    
}