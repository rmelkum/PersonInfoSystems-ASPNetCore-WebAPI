using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using PersonInfoSystems.Models;
using PersonInfoSystems.Contexts;
using PersonInfoSystems.Repositories;
using System.Threading.Tasks;

namespace PersonInfoSystems.Repositories;

public class AddressRepository : ICRUDRepository<AddressEntity>
{
    private readonly PersonInfoSystemsDbContext _context;

    public AddressRepository(PersonInfoSystemsDbContext context)
    {
        this._context = context;
    }
    public async Task<AddressEntity> Add(AddressEntity address)
    {
        try
        {
            this._context.Addresses.Add(address);
            await this._context.SaveChangesAsync();
            return address;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<AddressEntity>> GetAll()
    {
        try
        {
            return await this._context.Addresses.ToListAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<AddressEntity?> GetById(int id)
    {
        try
        {
            return await this._context.Addresses.FindAsync(id);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task Update(AddressEntity entity)
    {
        try
        {
            this._context.Addresses.Update(entity);
            await this._context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<bool> DeleteById(int id)
    {
        try
        {
            var deleteAddress = await this._context.Addresses.FindAsync(id);
            if(deleteAddress == null)
            {
                return false;
            }
            this._context.Addresses.Remove(deleteAddress);
            await this._context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}