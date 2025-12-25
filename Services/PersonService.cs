using System.Collections.Generic;
using System.Threading.Tasks;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;

namespace PersonInfoSystems.Services;

public class PersonService : ICRUDService<PersonEntity>
{
    private readonly ICRUDRepository<PersonEntity> _repository;

    public PersonService(ICRUDRepository<PersonEntity> repository)
    {
        this._repository = repository;
    }


    public async Task<PersonEntity> Add(PersonEntity city)
    {
        return await this._repository.Add(city);
    }

    public async Task<List<PersonEntity>> GetAll()
    {
        return await this._repository.GetAll();
    }

    public async Task<PersonEntity?> GetById(int id)
    {
        return await this._repository.GetById(id);
    }

    public async Task Update(PersonEntity city)
    {
        await this._repository.Update(city);
    }

    public async Task<bool> DeleteById(int id)
    {
        return await this._repository.DeleteById(id);
    }

}
