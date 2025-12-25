using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.Address;

public class CreateAddressDTO
{
    public int CityId { get; set; }

    [MaxLength(100)]
    [Required]
    public required string Adress { get; set; }

    [MaxLength(10)]
    [Required]
    public required string ZipCode { get; set; }  
}