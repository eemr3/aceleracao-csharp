using Microsoft.AspNetCore.Mvc;
using TrybeStore.Exceptions;
using TrybeStore.Models;
using TrybeStore.Repositories;

namespace TrybeStore.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly IUserRepository _repository;

  public UserController(IUserRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  public async Task<IActionResult> Register([FromBody] User userReq)
  {
    try
    {
      var userCreated = await _repository.AddUserAsync(userReq);

      return Created("", userCreated);
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