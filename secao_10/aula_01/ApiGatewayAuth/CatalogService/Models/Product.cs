using System.ComponentModel.DataAnnotations;

namespace CatalogService.Models;

public class Product
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = null!;

  [Required]
  public string Brand { get; set; } = null!;

  public decimal Price { get; set; }
}
