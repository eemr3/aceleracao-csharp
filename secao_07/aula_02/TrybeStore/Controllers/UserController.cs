using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrybeStore.Exceptions;
using TrybeStore.Models;
using TrybeStore.Repositories;
using TrybeStore.Services;

namespace TrybeStore.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly IUserRepository _repository;
  private readonly TokenGenerator _tokenGenerator;
  public UserController(IUserRepository repository, IConfiguration configuration)
  {
    _repository = repository;
    _tokenGenerator = new TokenGenerator(configuration);
  }

  [HttpPost]
  public async Task<IActionResult> Register([FromBody] User userReq)
  {
    try
    {
      var userCreated = await _repository.AddUserAsync(userReq);
      var token = _tokenGenerator.Generate(userReq);

      return Created("", new { access_token = token, name = userCreated.Name });
    }
    catch (ConflictException err)
    {

      return Conflict(new { message = err.Message });
    }
    catch (Exception err)
    {
      return StatusCode(500, err.Message);
    }
  }


  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Authorize]
  [HttpGet("{userId}")]
  public async Task<IActionResult> GetUserByEmail(int userId)
  {
    try
    {
      var user = await _repository.GetUserByIdAsync(userId);

      return Ok(user);
    }
    catch (KeyNotFoundException err)
    {
      return NotFound(new { message = err.Message });
    }
    catch (Exception err)
    {

      return StatusCode(500, err.Message);
    }
  }
}