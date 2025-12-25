using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using PersonInfoSystems.Models;
using PersonInfoSystems.Contexts;
using PersonInfoSystems.Repositories;
using System.Threading.Tasks;

namespace PersonInfoSystems.Repositories;


public class PersonAddressRepository
{
    private readonly PersonInfoSystemsDbContext _context;

    public PersonAddressRepository(PersonInfoSystemsDbContext context)
    {
        this._context = context;
    }

    public async Task<PersonAddressEntity> Add(PersonAddressEntity personAddress)
    {
        try
        {
            this._context.PersonAddresses.Add(personAddress);
            await this._context.SaveChangesAsync();
            return personAddress;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public async Task<List<PersonAddressEntity>> GetAll()
    {
        try
        {
            return await this._context.PersonAddresses.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public async Task<PersonAddressEntity?> GetById(int addressId, int personId)
    {
        try
        {
            return await _context.PersonAddresses.FindAsync(addressId,personId);
   
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public async Task Update(PersonAddressEntity personAddress)
    {
        try
        {
            this._context.PersonAddresses.Update(personAddress);
            await this._context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message {ex}");
            throw;
        }
    }

    public async Task<bool> DeleteById(int addressId, int personId)
    {
        try
        {
            var deletePersonAddress = await this._context.PersonAddresses.FindAsync(addressId,personId);

            if (deletePersonAddress == null)
            {
                return false;
            }
            this._context.PersonAddresses.Remove(deletePersonAddress);
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