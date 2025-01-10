using System.ComponentModel.DataAnnotations;

namespace Customer.DTO;
public class CustomerDtoRequest
{
  [Required(ErrorMessage = "Nome do cliente é obrigatório.")]
  [MinLength(3, ErrorMessage = "O nome do cliente precisar ter no mínimo 3 caracteres.")]
  public string Name { get; set; } = null!;

  [Required(ErrorMessage = "E email é obrigatório.")]
  [EmailAddress(ErrorMessage = "O endereço de email é inválido.")]
  public string Email { get; set; } = null!;
}