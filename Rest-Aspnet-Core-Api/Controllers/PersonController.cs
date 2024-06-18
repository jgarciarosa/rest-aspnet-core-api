using Core.Models;
using Infrastructure.Data;
using Infrastructure.Data.Dtos.Person;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(int id, [FromBody] UpdatePersonDto personDto)
    {
        var person = _context.Persons.FirstOrDefault(person => person.Id==id);
        if(person == null) return NotFound();
        person.FirstName = personDto.FirstName;
        person.LastName = personDto.LastName;
        person.Gender = personDto.Gender;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePatchFilme(int id, JsonPatchDocument<UpdatePersonDto> patch)
    {
        var person = _context.Persons.FirstOrDefault(person => person.Id == id);
        if (person == null) return NotFound();
        UpdatePersonDto personDto = new UpdatePersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender
        };
        patch.ApplyTo(personDto, ModelState);
        if (!TryValidateModel(personDto))
        {
            return ValidationProblem(ModelState);
        }
        person.FirstName = personDto.FirstName;
        person.LastName = personDto.LastName;
        person.Gender = personDto.Gender;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var person = _context.Persons.FirstOrDefault(person => person.Id == id);
        if (person == null) return NotFound();
        _context.Persons.Remove(person);
        _context.SaveChanges();
        return NoContent();
    }
}
