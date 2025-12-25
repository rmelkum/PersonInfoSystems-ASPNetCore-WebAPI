using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.City;
public class CreateCityDTO
{
    public int CountryId { get; set; }

    [MaxLength(100)]
    [Required]
    public required string Name { get; set; }

    public long Population { get; set; }
}