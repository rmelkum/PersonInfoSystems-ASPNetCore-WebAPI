using System;
using Microsoft.AspNetCore.Mvc;
using PersonInfoSystems.Repositories;
using PersonInfoSystems.DTOs.PersonAddress;

using System.Linq;
using PersonInfoSystems.Services;
using System.Threading.Tasks;

namespace PersonInfoSystems.Controllers;

[ApiController]
[Route("api/personaddresses")]
public class PersonAddressController : ControllerBase
{

    private readonly PersonAddressService _personAddressService;

    public PersonAddressController(PersonAddressService personAddressService)
    {
        this._personAddressService = personAddressService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allPersonAddresses = await this._personAddressService.GetAll();
        var allDTOPersonAddresses = allPersonAddresses.Select(personAddress => personAddress.ToReadDTO());
        return Ok(allDTOPersonAddresses);
    }

    [HttpGet("{addressId:int}/{personId:int}")]
    public async Task<IActionResult> Get(int addressId,int personId)
    {
        var personAddress = await _personAddressService.GetById(addressId,personId);
        if (personAddress == null)
        {
            return NotFound();
        }

        return Ok(personAddress.ToReadDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonAddressDTO createDTO)
    {
        try
        {
            var entityPersonAddress = createDTO.ToPersonAddressEntity();
            await _personAddressService.Add(entityPersonAddress);
            return Ok();
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpDelete("{addressId:int}/{personId:int}")]
    public async Task<IActionResult> Delete(int addressId, int personId)
    {
        var personAddress = await _personAddressService.GetById(addressId,personId);
        if(personAddress == null)
        {
            return NotFound();
        }
        await this._personAddressService.DeleteById(addressId,personId);
        return NoContent();
    }
}