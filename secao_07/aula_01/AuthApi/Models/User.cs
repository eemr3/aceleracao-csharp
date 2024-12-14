using System.ComponentModel.DataAnnotations;

namespace AuthApi.Models;

public class User
{
  [Key]
  public int UserId { get; set; }
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; }
  public string? Access { get; set; }
}