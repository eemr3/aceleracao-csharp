using System.ComponentModel.DataAnnotations;

namespace CatalogService.DTO;

public class ProductDtoRequest
{
  [Required(ErrorMessage = "Nome do produto é obrigatório")]
  [MinLength(3, ErrorMessage = "O nome do produto deve conter pelo menos 3 caracters")]
  public string Name { get; set; } = null!;

  [Required(ErrorMessage = "A marca do produto é obrigatório")]
  [MinLength(3, ErrorMessage = "A marca do produto deve conter pelo menos 3 caracters")]
  public string Brand { get; set; } = null!;

  [Range(1, int.MaxValue, ErrorMessage = "O preço do produto precisa ser maior que 0")]
  public decimal Price { get; set; }
}