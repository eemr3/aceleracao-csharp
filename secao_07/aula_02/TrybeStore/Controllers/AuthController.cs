using Microsoft.AspNetCore.Mvc;
using TrybeStore.DTO;
using TrybeStore.Exceptions;
using TrybeStore.Repositories;
using TrybeStore.Services;

namespace TrybeStore.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private IUserRepository _repository;
  private TokenGenerator _tokenGenerator;
  public AuthController(IUserRepository repository, IConfiguration configuration)
  {
    _repository = repository;
    _tokenGenerator = new TokenGenerator(configuration);
  }

  [HttpPost]
  public async Task<IActionResult> Login([FromBody] LoginDTORequest loginDto)
  {
    try
    {
      var user = await _repository.GetuserByEmailAsync(loginDto.Email!);
      if (user.Password != loginDto.Password) return Unauthorized(new { message = "Email address or password provided is incorrect." });

      var token = _tokenGenerator.Generate(user);

      return Ok(new { access_token = token });
    }
    catch (UnauthorizedException err)
    {

      return Unauthorized(new { message = err.Message });
    }

  }
}