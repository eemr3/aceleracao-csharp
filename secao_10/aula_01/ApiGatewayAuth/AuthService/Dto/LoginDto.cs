using System.ComponentModel.DataAnnotations;

namespace AuthService.Dto;

public class LoginDto
{
  [Required(ErrorMessage = "O endereço de email é obrigatório.")]
  public string Email { get; set; } = null!;

  [Required(ErrorMessage = "A senha é obrigatória.")]
  public string Password { get; set; } = null!;
}