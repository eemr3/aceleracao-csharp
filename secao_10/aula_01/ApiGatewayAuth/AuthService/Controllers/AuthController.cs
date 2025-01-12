using AuthService.Dto;
using AuthService.Exceptions;
using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IUserService _service;

  public AuthController(IUserService service)
  {
    _service = service;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] UserDtoRequest body)
  {
    try
    {
      var user = await _service.RegisterUser(body);

      return Created("", user);

    }
    catch (ConflictException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPost("login")]
  public async Task<IActionResult> SignIn(LoginDto loginDto)
  {
    try
    {
      var token = await _service.SignIn(loginDto);

      return Ok(new { access_token = token });
    }
    catch (UnauthorizedAccessException ex)
    {
      return Unauthorized(new { message = ex.Message });
    }
  }

}