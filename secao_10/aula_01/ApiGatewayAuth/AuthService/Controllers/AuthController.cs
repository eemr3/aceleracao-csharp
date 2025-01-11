using AuthService.DTO;
using AuthService.Filters;
using AuthService.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/auth")]
[TypeFilter(typeof(CustomExceptionsFilter))]
public class AuthController : ControllerBase
{
  private readonly IAuth _service;

  public AuthController(IAuth service)
  {
    _service = service;
  }

  [HttpPost("register")]
  public async Task<IActionResult> RegisterUser([FromBody] UserDtoRequest userDto)
  {
    var userAdd = await _service.SignUp(userDto);

    return Created($"api/users/{userAdd.UserId}", userAdd);
  }

  [HttpPost("login")]
  public async Task<IActionResult> SignIn([FromBody] LoginDtoRequest loginDto)
  {
    var token = await _service.SignIn(loginDto);

    return Ok(new { access_token = token });
  }
}