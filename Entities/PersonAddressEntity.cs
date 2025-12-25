using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystems.Models;

[Table("PersonAddress")]
public class PersonAddressEntity
{
    public int PersonId { get; set; }
    public int AdressId { get; set; }

    public PersonEntity PersonNavigation { get; set; } = null!;
    public AddressEntity AddressNavigation { get; set; } = null!;

}