using System.Collections.Generic;
using System.Threading.Tasks;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;

namespace PersonInfoSystems.Services;

public class AddressService : ICRUDService<AddressEntity>
{
    private readonly ICRUDRepository<AddressEntity> _repository;
    private readonly ICRUDRepository<CityEntity> _cityRepository;

    public AddressService(ICRUDRepository<AddressEntity> repository, ICRUDRepository<CityEntity> cityRepository)
    {
        this._repository = repository;
        this._cityRepository = cityRepository;
    }

    public async Task<AddressEntity> Add(AddressEntity address)
    {
        var city = await this._cityRepository.GetById(address.CityId);
        if(city == null)
        {
            throw new KeyNotFoundException($"City with id {address.CityId} was not found.");
        }
        return await this._repository.Add(address);
    }

    public async Task<List<AddressEntity>> GetAll()
    {
        return await this._repository.GetAll();
    }

    public async Task<AddressEntity?> GetById(int id)
    {
        return await this._repository.GetById(id);
    }

    public async Task Update(AddressEntity address)
    {
        await this._repository.Update(address);
    }
    
    public async Task<bool> DeleteById(int id)
    {
        return await this._repository.DeleteById(id);
    }
}