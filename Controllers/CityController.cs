using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PersonInfoSystems.Models;
using PersonInfoSystems.Repositories;
using PersonInfoSystems.DTOs.City;
using PersonInfoSystems.Services;
using System.Threading.Tasks;


[ApiController]
[Route("api/cities")]
public class CityController : ControllerBase
{
    private readonly ICRUDService<CityEntity> _cityService;

    public CityController(ICRUDService<CityEntity> cityRepository)
    {
        this._cityService = cityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allCityEntities = await this._cityService.GetAll();
        var allDTOCities = allCityEntities.Select(city => city.ToReadDTO()).ToList();
        return Ok(allDTOCities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var city = await this._cityService.GetById(id);

        if (city == null)
        {
            return NotFound();
        }
        var DTOCity = city.ToReadDTO();
        return Ok(DTOCity);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCityDTO createDTO)
    {
        try
        {
            var entityCity = createDTO.ToCityEntity();
            await this._cityService.Add(entityCity);
            var readDto = entityCity.ToReadDTO();
            return CreatedAtAction(nameof(GetById), new { id = entityCity.CityId }, readDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCityDTO cityDTO)
    {
        var updateCity = await this._cityService.GetById(id);
        if (updateCity == null)
        {
            return NotFound();
        }

        cityDTO.UpdateEntity(updateCity);
        await this._cityService.Update(updateCity);
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteCity = await this._cityService.GetById(id);
        if (deleteCity == null)
        {
            return NotFound();
        }
        await this._cityService.DeleteById(id);
        return NoContent();
    }
}