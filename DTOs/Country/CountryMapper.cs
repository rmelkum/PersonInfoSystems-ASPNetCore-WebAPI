using PersonInfoSystems.Models;

namespace PersonInfoSystems.DTOs.Country;

public static class CountryMapper
{
    public static ReadCountryDTO ToReadDTO(this CountryEntity countryEntity)
    {
        ReadCountryDTO countryForRead = new ReadCountryDTO();

        countryForRead.CountryId = countryEntity.CountryId;
        countryForRead.Name = countryEntity.Name;
        countryForRead.Continent = countryEntity.Continent;
        countryForRead.Population = countryEntity.Population;
        countryForRead.Currency = countryEntity.Currency;

        return countryForRead;
    }

    public static CountryEntity ToCountryEntity(this CreateCountryDTO countryDTO)
    {
        CountryEntity country = new CountryEntity();
        country.Name = countryDTO.Name;
        country.Continent = countryDTO.Continent;
        country.Population = countryDTO.Population;
        country.Currency = countryDTO.Currency;

        return country;
    }
    
public static void UpdateEntity(this UpdateCountryDTO countryDTO, CountryEntity entity)
{
    entity.Name = countryDTO.Name;
    entity.Continent = countryDTO.Continent;
    entity.Population = countryDTO.Population;
    entity.Currency = countryDTO.Currency;
}

}