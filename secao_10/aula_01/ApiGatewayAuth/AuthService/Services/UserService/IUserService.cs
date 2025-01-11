using AuthService.DTO;
using AuthService.Models;

namespace AuthService.Services.UserService;

public interface IUserService
{
  // public Task<UserDtoResponse> AddUserAsync(UserDtoRequest userDto);
  public Task<UserDtoResponse> GetUserByIdAsync(int userId);
  public Task<UserDtoResponse> UpdateUserAsync(User user);
}