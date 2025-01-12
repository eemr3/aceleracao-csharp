using System.ComponentModel.DataAnnotations;

namespace AuthService.Dto;

public class UserDtoRequest
{
  [Required(ErrorMessage = "O nome é obrigatório")]
  [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome tem que ter no minímo 3 e no maxímo 100 caractares")]
  public string Name { get; set; } = null!;

  [Required(ErrorMessage = "O email é obrigatório")]
  [EmailAddress(ErrorMessage = "O email deve ser um email válido")]
  public string Email { get; set; } = null!;

  [Required(ErrorMessage = "A senha é obrigatória")]
  public string Password { get; set; } = null!;
  public string? Role { get; set; }
}