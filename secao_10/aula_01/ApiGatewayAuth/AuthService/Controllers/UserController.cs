using AuthService.DTO;
using AuthService.Filters;
using AuthService.Models;
using AuthService.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/users")]
[TypeFilter(typeof(CustomExceptionsFilter))]
public class UserController : ControllerBase
{
  private readonly IUserService _service;

  public UserController(IUserService service)
  {
    _service = service;
  }

  [HttpGet("{userId}")]
  public async Task<IActionResult> GetUserById(int userId)
  {
    var user = await _service.GetUserByIdAsync(userId);

    return Ok(user);
  }

  [HttpPut]
  public async Task<IActionResult> UpdateUser([FromBody] User user)
  {
    var userUpdated = await _service.UpdateUserAsync(user);

    return Ok(userUpdated);
  }
}