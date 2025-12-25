using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PersonInfoSystems.Contexts;
using PersonInfoSystems.DTOs.Person;
using PersonInfoSystems.Repositories;
using PersonInfoSystems.Models;
using PersonInfoSystems.Services;
using System.Threading.Tasks;

namespace PersonInfoSystems.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonController : ControllerBase
{
    private readonly ICRUDService<PersonEntity> _personService;

    public PersonController(ICRUDService<PersonEntity>  personRepository)
    {
        this. _personService =  personRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allPersons = await this. _personService.GetAll();
        var allDTOPersons = allPersons.Select(person => person.ToReadDTO());
        return Ok(allDTOPersons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await this. _personService.GetById(id);
        if (person == null)
        {
            return NotFound();
        }

        var DTOPerson = person.ToReadDTO();
        return Ok(DTOPerson);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonDTO createDTO)
    {
        var entityPerson = createDTO.ToPersonEntity();
        await this._personService.Add(entityPerson);
        var readDto = entityPerson.ToReadDTO();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePersonDTO personDTO)
    {
        var person = await this._personService.GetById(id);
        if (person == null)
        {
            return NotFound();
        }

        personDTO.UpdateEntity(person);
        await this._personService.Update(person);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await  this._personService.GetById(id);
        if (person == null)
        {
            return NotFound();
        }
        await this._personService.DeleteById(id);
        return NoContent();
    }

}