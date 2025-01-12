using System.ComponentModel.DataAnnotations;

namespace AuthService.Models;

public class User
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = null!;

  [Required]
  public string Email { get; set; } = null!;

  [Required]
  public string PasswordHash { get; set; } = null!;
  public string? Role { get; set; } // Ex: "admin", "user"
}