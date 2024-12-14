using AuthApi.DTO;
using AuthApi.Models;
using AuthApi.Repositories;
using AuthApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controller;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
  private readonly IUserRepository _repository;
  private readonly TokenGenerator _tokenGenerator;
  public UserController(IUserRepository repository)
  {
    _repository = repository;
    _tokenGenerator = new TokenGenerator();
  }

  [HttpPost]
  public async Task<IActionResult> AddUser([FromBody] User user)
  {
    var userCreated = await _repository.AddUser(user);
    var token = _tokenGenerator.Generate(user);
    return Created("", new { token });
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDTORequest loginDTO)
  {
    try
    {
      var userExists = await _repository.GetUserByEmail(loginDTO.Email);

      if (userExists.Password != loginDTO.Password) return Unauthorized(new { message = "Incorrect email or passaword" });

      var token = _tokenGenerator.Generate(userExists);
      return Ok(new { token });

    }
    catch (KeyNotFoundException)
    {
      return Unauthorized(new { message = "Incorrect email or password!" });
    }
  }

  [HttpGet("{userId}")]
  public async Task<IActionResult> GetUserById(int userId)
  {
    try
    {
      var user = await _repository.GetUserById(userId);

      return Ok(user);

    }
    catch (KeyNotFoundException err)
    {
      return NotFound(new { message = err.Message });
    }
  }
}