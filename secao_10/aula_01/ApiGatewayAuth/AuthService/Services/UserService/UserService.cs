using AuthService.DTO;
using AuthService.Models;
using AuthService.Repositories;

namespace AuthService.Services.UserService;

public class UserService : IUserService
{
  private readonly IUserRepository _repository;

  public UserService(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<UserDtoResponse> GetUserByIdAsync(int userId)
  {
    var user = await _repository.GetUserByIdAsync(userId);

    if (user is null) throw new KeyNotFoundException($"O usuário com ID {userId} não foi encontrado.");

    return new UserDtoResponse
    {
      UserId = user.UserId,
      Name = user.Name,
      Email = user.Email,
      Role = user.Role,
    };
  }

  public async Task<UserDtoResponse> UpdateUserAsync(User user)
  {

    var userUpdated = await _repository.UpdateUserAsync(user);

    if (userUpdated is null) throw new KeyNotFoundException($"O usuário com ID {user.UserId} não foi encontrado.");

    return new UserDtoResponse
    {
      UserId = userUpdated.UserId,
      Name = userUpdated.Name,
      Email = userUpdated.Email,
      Role = userUpdated.Role,
    };
  }
}