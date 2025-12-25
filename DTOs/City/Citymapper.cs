using System;
using PersonInfoSystems.Models;

namespace PersonInfoSystems.DTOs.City;

public static class CityMapper
{

    public static ReadCityDTO ToReadDTO(this CityEntity cityEntity)
    {
        ReadCityDTO cityForRead = new ReadCityDTO();
        cityForRead.CityId = cityEntity.CityId;
        cityForRead.CountryId = cityEntity.CountryId;
        cityForRead.Name = cityEntity.Name;
        cityForRead.Population = cityEntity.Population;

        return cityForRead;
    }

    public static CityEntity ToCityEntity(this CreateCityDTO cityDTO)
    {
        CityEntity city = new CityEntity();
        city.CountryId = cityDTO.CountryId;
        city.Name = cityDTO.Name;
        city.Population = cityDTO.Population;

        return city;
    }

    public static void UpdateEntity(this UpdateCityDTO cityDTO, CityEntity entity)
    {
        entity.CountryId = cityDTO.CountryId;
        entity.Name = cityDTO.Name;
        entity.Population = cityDTO.Population;
    }
}