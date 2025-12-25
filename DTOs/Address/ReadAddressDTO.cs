using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfoSystems.DTOs.Address;

public class ReadAddressDTO
{
    public int AdressId { get; set; }

    public int CityId { get; set; }

    [MaxLength(100)]
    public string? Adress { get; set; }

    [MaxLength(10)]
    public string? ZipCode { get; set; }  
}