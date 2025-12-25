using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystems.Models;

[Table("City")]
public class CityEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CityId { get; set; }
    [ForeignKey("CountryNavigation")]
    public int CountryId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public long Population { get; set; }

    public CountryEntity CountryNavigation { get; set; } = null!;
    public List<AddressEntity> Adressies { get; set; } = new List<AddressEntity>();

    public CityEntity(int cityId, int countryId, string name, long population)
    {
        this.CityId = cityId;
        this.CountryId = countryId;
        this.Name = name;
        this.Population = population;
    }

    public CityEntity()
    { }

        public override string ToString()
    {
        return $"CityId: {this.CityId}, CountryId: {this.CountryId}, Name: {this.Name}, Population: {this.Population}";
    }
}