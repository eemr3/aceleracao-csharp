using TrybeStore.DTO;
using TrybeStore.Models;

namespace TrybeStore.Repositories;

public interface IUserRepository
{
  public Task<User> AddUserAsync(User user);
  public Task<User> GetuserByEmailAsync(string email);
  public Task<UserDTO> GetUserByIdAsync(int userId);
}