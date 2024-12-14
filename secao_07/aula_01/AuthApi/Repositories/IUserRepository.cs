using AuthApi.DTO;
using AuthApi.Models;

namespace AuthApi.Repositories;

public interface IUserRepository
{
  public Task<User> AddUser(User user);
  public Task<UserDTO> GetUserById(int userId);
  public Task<User> GetUserByEmail(string email);
}