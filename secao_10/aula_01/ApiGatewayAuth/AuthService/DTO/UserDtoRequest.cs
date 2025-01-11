using System.ComponentModel.DataAnnotations;

namespace AuthService.DTO;

public class UserDtoRequest
{
  [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
  [MinLength(3, ErrorMessage = "O nome do usuário precisa ter no minímo 3 caracteres.")]
  public string Name { get; set; } = null!;

  [Required(ErrorMessage = "O endereço de email é o brigatório.")]
  [EmailAddress(ErrorMessage = "O endereço de email não válido.")]
  public string Email { get; set; } = null!;

  [Required]
  [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha tem que ter no mínimo 6 caracteres e no máximo 30.")]
  public string Password { get; set; } = null!;
}