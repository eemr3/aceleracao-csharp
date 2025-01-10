using System.ComponentModel.DataAnnotations;

namespace AuthService.Models;

public class User
{
  public int UserId { get; set; }

  [Required]
  public string Name { get; set; } = null!;

  [Required]
  public string Email { get; set; } = null!;

  [Required]
  public string PasswordHash { get; set; } = null!;

  public string? Role { get; set; }
}