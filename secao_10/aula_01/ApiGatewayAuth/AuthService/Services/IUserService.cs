using AuthService.Dto;
using AuthService.Models;

namespace AuthService.Services;

public interface IUserService
{
  public Task<UserDtoResponse> RegisterUser(UserDtoRequest user);
  public Task<string> SignIn(LoginDto loginDto);
}