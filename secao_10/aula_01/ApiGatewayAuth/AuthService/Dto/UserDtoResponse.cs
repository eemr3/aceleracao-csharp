namespace AuthService.Dto;

public class UserDtoResponse
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Role { get; set; }
}