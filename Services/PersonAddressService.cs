using System.Collections.Generic;
using System.Threading.Tasks;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;

namespace PersonInfoSystems.Services;

public class PersonAddressService
{
    private readonly PersonAddressRepository _repository;
    private readonly ICRUDRepository<PersonEntity> _personRepository;
    private readonly ICRUDRepository<AddressEntity> _addressRepository;

    public PersonAddressService(PersonAddressRepository repository, ICRUDRepository<PersonEntity> personRepository, ICRUDRepository<AddressEntity> addressRepository)
    {
        this._repository = repository;
        this._personRepository = personRepository;
        this._addressRepository = addressRepository;
    }

    public async Task<PersonAddressEntity> Add(PersonAddressEntity personAddress)
    {
        var person = await this._personRepository.GetById(personAddress.PersonId);
        if (person == null)
        {
            throw new KeyNotFoundException($"Person with id {personAddress.PersonId} was not found");
        }

        var address = await this._addressRepository.GetById(personAddress.AdressId);
        if (address == null)
        {
            throw new KeyNotFoundException($"Address with id {personAddress.AdressId} was not found");
        }
        return await _repository.Add(personAddress);
    }

    public async Task<List<PersonAddressEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<PersonAddressEntity?> GetById(int addressId, int personId)
    {
        return await _repository.GetById(addressId,personId);
    }

    public async Task Update(PersonAddressEntity personAddress)
    {
        await _repository.Update(personAddress);
    }

    public async Task<bool> DeleteById(int addressId, int personId)
    {
        return await _repository.DeleteById(addressId,personId);
    }
}
