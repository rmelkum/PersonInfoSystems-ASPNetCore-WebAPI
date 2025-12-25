using System.Collections.Generic;
using System.Threading.Tasks;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;

namespace PersonInfoSystems.Services;

public class CountryService : ICRUDService<CountryEntity>
{
    private readonly ICRUDRepository<CountryEntity> _repository;

    public CountryService(ICRUDRepository<CountryEntity> repository)
    {
        this._repository = repository;
    }


    public async Task<CountryEntity> Add(CountryEntity city)
    {
        return await this._repository.Add(city);
    }

    public async Task<List<CountryEntity>> GetAll()
    {
        return await this._repository.GetAll();
    }

    public async Task<CountryEntity?> GetById(int id)
    {
        return await this._repository.GetById(id);
    }

    public async Task Update(CountryEntity city)
    {
        await this._repository.Update(city);
    }

    public async Task<bool> DeleteById(int id)
    {
        return await this._repository.DeleteById(id);
    }

}
