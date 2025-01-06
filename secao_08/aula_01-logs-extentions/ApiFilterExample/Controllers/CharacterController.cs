using ApiFilterExample.Filteres;
using ApiFilterExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilterExample.Controllers;

[ApiController]
[Route("api/v1/characters")]
public class CharacterController : ControllerBase
{
  private readonly ICharacterService _service;

  public CharacterController(ICharacterService service)
  {
    _service = service;
  }

  [HttpGet]
  public IActionResult GetAllCharacter()
  {
    var characters = _service.GetCharacters();

    return Ok(characters);
  }

  [HttpGet("{id}")]
  [TypeFilter(typeof(NotFoundExceptionFilter))]
  public IActionResult GetCharacterById(int id)
  {
    var character = _service.GetCharacterById(id);

    return Ok(character);
  }
}