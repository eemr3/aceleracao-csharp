using AuthService.DTO;

namespace AuthService.Services.Auth;

public interface IAuth
{
  public Task<UserDtoResponse> SignUp(UserDtoRequest register);

  public Task<string> SignIn(LoginDtoRequest login);
}