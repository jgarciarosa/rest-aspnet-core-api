using Core.Models;
using Infrastructure.Data;
using Infrastructure.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Rest_Aspnet_Core_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private PersonContext _context;

    public PersonController(PersonContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreatePerson([FromBody] CreatePersonDto personDto)
    {
        Person person = new Person
        {
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Gender = personDto.Gender
        };
        _context.Persons.Add(person);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
    }

    [HttpGet("{id}")]
    public IActionResult GetPersonById(int id)
    {
        var person = _context.Persons.FirstOrDefault(person => person.Id == id);
        if(person == null) return NotFound();
        ReadPersonDto personDto = new ReadPersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender
        };
        return Ok(personDto);
    }

    [HttpGet]
    public IEnumerable<ReadPersonDto> GetPersons()
    {
        List<ReadPersonDto> personDtos = new List<ReadPersonDto>();
        foreach(Person person in _context.Persons)
        {
            ReadPersonDto personDto = new ReadPersonDto
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender
            };
            personDtos.Add(personDto);
        }
        return personDtos;
    }
}
