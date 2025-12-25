using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.City;

public class UpdateCityDTO
{
    public int CountryId { get; set; }


    [MaxLength(100)]
    [Required]
    public required string Name { get; set; }

    public required long Population { get; set; }
}