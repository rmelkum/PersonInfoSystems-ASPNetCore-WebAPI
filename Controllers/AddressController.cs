using Microsoft.AspNetCore.Mvc;
using PersonInfoSystems.Models;
using PersonInfoSystems.DTOs.Address;
using PersonInfoSystems.Services;
using System.Linq;

namespace PersonInfoSystems.Controllers;

[ApiController]
[Route("api/addresses")]
public class AddressController : ControllerBase
{
    private readonly ICRUDService<AddressEntity> _service;

    public AddressController(ICRUDService<AddressEntity> service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allAdresies = await  this._service.GetAll();
        var  allDTOAddresies = allAdresies.Select(address => address.ToReadDTO());
        return Ok(allDTOAddresies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var address = await this._service.GetById(id);
        if (address == null)
        {
            return NotFound();
        }
        var DTOAddress = address.ToReadDTO();
        return Ok(DTOAddress);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAddressDTO creatDTO)
    {
        try
        {
            var entityAddress = creatDTO.ToAddressEntity();
            await this._service.Add(entityAddress);
            return Ok();
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAddressDTO addressDTO)
    {
        var address = await this._service.GetById(id);
        if (address == null)
        {
            return NotFound();
        }
        addressDTO.UpdateEntity(address);
        await this._service.Update(address);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var address = await this._service.GetById(id);
        if (address == null)
        {
            return NotFound();
        }
        await this._service.DeleteById(id);
        return NoContent();
    }
}