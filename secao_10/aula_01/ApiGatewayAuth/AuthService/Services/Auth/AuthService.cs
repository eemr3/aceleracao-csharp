using AuthService.DTO;
using AuthService.Models;
using AuthService.Repositories;
using AuthService.Services.JWT;
using BCrypt.Net;

namespace AuthService.Services.Auth;

public class Auth : IAuth
{
  private readonly IUserRepository _repository;
  private readonly TokenGenerator _tokenGenerator;
  public Auth(IUserRepository repository)
  {
    _repository = repository;
    _tokenGenerator = new TokenGenerator();
  }
  public async Task<UserDtoResponse> SignUp(UserDtoRequest userDto)
  {
    var passwrdHashad = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
    var user = new User
    {
      Name = userDto.Name,
      Email = userDto.Email,
      PasswordHash = passwrdHashad,
      Role = "client"
    };

    var userCreated = await _repository.AddUserAsync(user);

    return new UserDtoResponse
    {
      UserId = userCreated.UserId,
      Name = userCreated.Name,
      Email = userCreated.Email,
      Role = userCreated.Role,

    };
  }

  public async Task<string> SignIn(LoginDtoRequest login)
  {
    var user = await _repository.GetUserByEmailAsync(login.Email);

    if (user is null) throw new UnauthorizedAccessException("Email address or password provided is incorrect.");

    if (!BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash)) throw new UnauthorizedAccessException("Email address or password provided is incorrect.");

    var token = _tokenGenerator.Generator(user);

    return token;
  }
}