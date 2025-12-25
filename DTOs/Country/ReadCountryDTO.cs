using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.Country;

public class ReadCountryDTO
{
     public int CountryId { get; set; }
    public string? Name { get; set; }
    public string? Continent { get; set; }
    public long Population { get; set; }
    public string? Currency { get; set; }

}