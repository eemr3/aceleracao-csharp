using System.ComponentModel.DataAnnotations;

namespace UserApi.Models;

public class User
{
  public int UserId { get; set; }
  public string Name { get; set; } = null!;
  [EmailAddress]
  public string Email { get; set; }

}