using ContactList.Models;
using ContactList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
  private readonly IContactRepository _repository;

  public ContactController(IContactRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> GetContacts()
  {
    var contacts = await _repository.GetContacts();

    return Ok(contacts);
  }

  [HttpPost]
  public async Task<IActionResult> AddContact([FromBody] Contact contact)
  {
    var createdContact = await _repository.AddContact(contact);

    return Created("", createdContact);
  }

  [HttpPut]
  public async Task<IActionResult> PutContact([FromBody] Contact contact)
  {
    try
    {
      var updatedContact = await _repository.UpdateContact(contact);

      return Ok(updatedContact);
    }
    catch (KeyNotFoundException ex)
    {

      return NotFound(new { message = ex.Message });
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteContact(int id)
  {
    try
    {
      await _repository.DeleteContact(id);

      return NoContent();
    }
    catch (KeyNotFoundException ex)
    {
      return NotFound(new { message = ex.Message });
    }
  }
}