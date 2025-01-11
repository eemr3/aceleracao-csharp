using AuthService.Models;

namespace AuthService.Repositories;

public interface IUserRepository
{
  public Task<User> AddUserAsync(User user);
  public Task<User?> GetUserByEmailAsync(string email);
  public Task<User?> GetUserByIdAsync(int userId);
  public Task<User?> UpdateUserAsync(User user);
}