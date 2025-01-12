using AuthService.Dto;
using AuthService.Models;

namespace AuthService.Repositories;

public interface IUserRepository
{
  public Task<UserDtoResponse> AddUserAsync(User user);
  public Task<User?> GetUserByEmail(string email);
}