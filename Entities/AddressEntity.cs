using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystems.Models;

[Table("Address")]
public class AddressEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AdressId { get; set; }

    [ForeignKey("CityNavigation")]
    public int CityId { get; set; }

    [MaxLength(100)]
    public string Adress { get; set; } = null!;

    [MaxLength(10)]
    public string ZipCode { get; set; } = null!;

    public CityEntity CityNavigation { get; set; } = null!;
    public List<PersonAddressEntity> PersonAddresses { get; set; } = new List<PersonAddressEntity>();

    public AddressEntity(int cityid, string adressName, string zipCode)
    {
        this.CityId = cityid;
        this.Adress = adressName;
        this.ZipCode = zipCode;
    }

    public AddressEntity()
    { }
}