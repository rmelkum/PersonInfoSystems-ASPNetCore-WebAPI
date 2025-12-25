using Microsoft.AspNetCore.Mvc;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;
using PersonInfoSystems.DTOs.Country;
using System.Linq;
using System.Threading.Tasks;
using PersonInfoSystems.Services;

namespace PersonInfoSystems.Controllers;

[ApiController]
[Route("api/countries")]
public class CountryController : ControllerBase
{
    private readonly ICRUDService<CountryEntity> _countryService;

    public CountryController(ICRUDService<CountryEntity> countryRepository)
    {
        this._countryService = countryRepository;
    } 

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allCountryEntities = await this._countryService.GetAll();
        var allDTOCountries = allCountryEntities.Select(country => country.ToReadDTO()).ToList();
        return Ok(allDTOCountries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var country = await this._countryService.GetById(id);

        if (country == null)
        {
            return NotFound();
        }
        var DTOCountry = country.ToReadDTO();
        return Ok(DTOCountry);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCountryDTO createDTO)
    {
        var entityCountry = createDTO.ToCountryEntity();
        await this._countryService.Add(entityCountry);

        var readDto = entityCountry.ToReadDTO();
        return Ok();
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, UpdateCountryDTO countryDTO)
    {
        var updateCountry = await this._countryService.GetById(id);

        if (updateCountry == null)
        {
            return NotFound();
        }
        countryDTO.UpdateEntity(updateCountry);
        await this._countryService.Update(updateCountry);

        return NoContent();

    }

    [HttpDelete("{id}")]
    
    public async Task<IActionResult> Delete(int id)
    {
        var deleteCountry = await this._countryService.GetById(id);

        if (deleteCountry == null)
        {
            return NotFound();
        }
        await this._countryService.DeleteById(id);
        return NoContent();
    }

}