using System;
using PersonInfoSystems.Models;

namespace PersonInfoSystems.DTOs.Address;

public static class AddressMapper
{

    public static ReadAddressDTO ToReadDTO(this AddressEntity addressEntity)
    {
        ReadAddressDTO addressForRead = new ReadAddressDTO();
        addressForRead.AdressId = addressEntity.AdressId;
        addressForRead.CityId = addressEntity.CityId;
        addressForRead.Adress = addressEntity.Adress;
        addressForRead.ZipCode = addressEntity.ZipCode;
        return addressForRead;

    }
    public static AddressEntity ToAddressEntity(this CreateAddressDTO addressDTO)
    {
        AddressEntity address = new AddressEntity();
        address.CityId = addressDTO.CityId;
        address.Adress = addressDTO.Adress;
        address.ZipCode = addressDTO.ZipCode;
        return address;
    }
    public static void UpdateEntity(this UpdateAddressDTO addressDTO, AddressEntity addressEntity)
    {
        addressEntity.CityId = addressDTO.CityId;
        addressEntity.Adress = addressDTO.Adress;
        addressEntity.ZipCode = addressDTO.ZipCode;
    }
}