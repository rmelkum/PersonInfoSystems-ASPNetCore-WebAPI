using System;
using PersonInfoSystems.DTOs.PersonAddress;
using PersonInfoSystems.Models;

namespace PersonInfoSystems.DTOs.PersonAddress;
public static class PersonAddressMapper
{
    public static ReadPersonAddressDTO ToReadDTO(this PersonAddressEntity personAddressEntity)
    {
        ReadPersonAddressDTO personAddressForRead = new ReadPersonAddressDTO();
        personAddressForRead.PersonId = personAddressEntity.PersonId;
        personAddressForRead.AdressId = personAddressEntity.AdressId;
        return personAddressForRead;
    }

    public static PersonAddressEntity ToPersonAddressEntity(this CreatePersonAddressDTO personAddressDTO)
    {
        PersonAddressEntity personAddressEntity = new PersonAddressEntity();
        personAddressEntity.PersonId = personAddressDTO.PersonId;
        personAddressEntity.AdressId = personAddressDTO.AdressId;
        return personAddressEntity;
    }

    public static void UpdateEntity(this UpdatePersonAddressDTO personAddressDTO, PersonAddressEntity personAddressEntity)
    {
        personAddressEntity.PersonId = personAddressDTO.PersonId;
        personAddressEntity.AdressId = personAddressDTO.AdressId;
    }
}
