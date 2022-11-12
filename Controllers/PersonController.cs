namespace ColaAplication.Controllers;

using Microsoft.AspNetCore.Mvc;
using ColaAplication.Services;
using ColaAplication.Models;
using ColaAplication;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    IPersonService _personService;
    PersonContext _personContext;

    public PersonController(IPersonService personService, PersonContext personContext)
    {
        _personService = personService;
        _personContext = personContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        _personService.Save(person);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Person person)
    {
        _personService.Update(id, person);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _personService.Delete(id);
        return Ok();
    }

    [HttpGet]
    [Route("createDb")]
    public IActionResult CreateDb()
    {
        _personContext.Database.EnsureCreated();
        return Ok();
    }
}
