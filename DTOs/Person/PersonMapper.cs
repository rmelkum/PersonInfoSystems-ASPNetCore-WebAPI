using System;
using PersonInfoSystems.Models;

namespace PersonInfoSystems.DTOs.Person;

public static class PersonMapper
{

    public static ReadPersonDTO ToReadDTO(this PersonEntity personEntity)
    {
        ReadPersonDTO personForRead = new ReadPersonDTO();

        personForRead.Id = personEntity.Id;
        personForRead.Name = personEntity.Name;
        personForRead.Surname = personEntity.Surname;
        personForRead.Age = personEntity.Age;
        personForRead.Mail = personEntity.Mail;
        personForRead.NationalID = personEntity.NationalID;
        personForRead.Gender = personEntity.Gender;
        personForRead.PhoneNumber = personEntity.PhoneNumber;
        personForRead.DateOfBirth = personEntity.DateOfBirth;

        return personForRead;
        
    }
    public static PersonEntity ToPersonEntity(this CreatePersonDTO personDTO)
    {
        PersonEntity personEntity = new PersonEntity();

        personEntity.Name = personDTO.Name;
        personEntity.Surname = personDTO.Surname;
        personEntity.Age = personDTO.Age;
        personEntity.Mail = personDTO.Mail;
        personEntity.NationalID = personDTO.NationalID;
        personEntity.Gender = personDTO.Gender;
        personEntity.PhoneNumber = personDTO.PhoneNumber;
        personEntity.DateOfBirth = personDTO.DateOfBirth;

        return personEntity;
    }
    
    public static void UpdateEntity(this UpdatePersonDTO personDTO, PersonEntity personEntity)
    {
        personEntity.Name = personDTO.Name;
        personEntity.Surname = personDTO.Surname;
        personEntity.Age = personDTO.Age;
        personEntity.Mail = personDTO.Mail;
        personEntity.NationalID = personDTO.NationalID;
        personEntity.Gender = personDTO.Gender;
        personEntity.PhoneNumber = personDTO.PhoneNumber;
        personEntity.DateOfBirth = personDTO.DateOfBirth;  
        
    }

}