using AuthService.Dto;
using AuthService.Models;
using AuthService.Repositories;

namespace AuthService.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _repository;
  private readonly TokenGenerator tokenGenerator;
  private readonly PasswordService passwordService;
  public UserService(IUserRepository repository, IConfiguration configuration)
  {
    _repository = repository;
    tokenGenerator = new TokenGenerator(configuration);
    passwordService = new PasswordService();
  }

  public async Task<UserDtoResponse> RegisterUser(UserDtoRequest userDto)
  {
    var user = new User
    {
      Name = userDto.Name,
      PasswordHash = passwordService.HashPassword(userDto.Password),
      Email = userDto.Email,
      Role = userDto.Role
    };

    return await _repository.AddUserAsync(user);
  }

  public async Task<string> SignIn(LoginDto loginDto)
  {
    var user = await _repository.GetUserByEmail(loginDto.Email!);
    if (user is null) throw new UnauthorizedAccessException("Email ou senha incorretos!");
    if (passwordService.VerifyPassword(user.PasswordHash, loginDto.Password!)) throw new UnauthorizedAccessException("Email ou senha incorretos!");

    var token = tokenGenerator.Generator(user);

    return token;
  }
}