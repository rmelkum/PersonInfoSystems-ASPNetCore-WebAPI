using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.Country;

public class CreateCountryDTO
{
    [MaxLength(100)]
    [Required]
    public required string Name { get; set; }

    [MaxLength(20)]
    [Required]
    public required string Continent { get; set; }
    public long Population { get; set; }

    [MaxLength(10)]
    [Required]
    public required string Currency { get; set; }

}