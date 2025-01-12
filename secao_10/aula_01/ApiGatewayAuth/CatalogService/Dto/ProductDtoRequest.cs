using System.ComponentModel.DataAnnotations;

namespace CatalogService.Dto;

public class ProductDtoRequest
{
  [Required(ErrorMessage = "O nome do produto é obrigatório.")]
  [StringLength(70, MinimumLength = 3, ErrorMessage = "O nome do produto tem que ter no mínimo 3 e no maxímo 70 caracteres")]
  public string Name { get; set; } = null!;

  [Required(ErrorMessage = "A marca do  produto é obrigatória.")]
  [StringLength(30, MinimumLength = 3, ErrorMessage = "A marca produto tem que ter no mínimo 3 e no maxímo 30 caracteres")]
  public string Brand { get; set; } = null!;

  [Range(0, double.MaxValue, ErrorMessage = "O preço precisa não pode ser negativo.")]
  public decimal Price { get; set; }
}