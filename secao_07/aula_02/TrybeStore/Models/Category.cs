using System.ComponentModel.DataAnnotations;

namespace TrybeStore.Models;

public class Category
{
  [Key]
  public int CategoryId { get; set; }
  public string? Name { get; set; }
  public ICollection<Product>? Products { get; set; }
}