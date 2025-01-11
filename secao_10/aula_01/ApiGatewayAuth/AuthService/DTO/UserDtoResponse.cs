namespace AuthService.DTO;

public class UserDtoResponse
{
  public int UserId { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Role { get; set; }
}