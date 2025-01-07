using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models;

public class Product
{
  public int Id { get; set; }
  [MinLength(5, ErrorMessage = "Name precisa ter pelo menos 5 caracteres")]
  public string Name { get; set; }
  [Required(ErrorMessage = "A descrição é obrigatória")]
  public string Description { get; set; }

  [Range(1, 100, ErrorMessage = "O preço é obrigatório!")]
  public float Price { get; set; }
}