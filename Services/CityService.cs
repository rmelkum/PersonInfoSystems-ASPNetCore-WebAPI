using System.Collections.Generic;
using System.Threading.Tasks;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;

namespace PersonInfoSystems.Services;

public class CityService : ICRUDService<CityEntity>
{
    private readonly ICRUDRepository<CityEntity> _repository;
    private readonly ICRUDRepository<CountryEntity> _countryRepository;

    public CityService(ICRUDRepository<CityEntity> repository,ICRUDRepository<CountryEntity> countryRepository)
    {
        this._repository = repository;
        this._countryRepository = countryRepository;
    }


    public async Task<CityEntity> Add(CityEntity city)
    {
        var country = await this._countryRepository.GetById(city.CountryId);
        if(country == null)
        {
            throw new KeyNotFoundException($"Country with id {city.CountryId} was not found.");
        }
        return await this._repository.Add(city);
    }

    public async Task<List<CityEntity>> GetAll()
    {
        return await this._repository.GetAll();
    }

    public async Task<CityEntity?> GetById(int id)
    {
        return await this._repository.GetById(id);
    }

    public async Task Update(CityEntity city)
    {
        await this._repository.Update(city);
    }

    public async Task<bool> DeleteById(int id)
    {
        return await this._repository.DeleteById(id);
    }

}
