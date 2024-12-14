using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrybeStore.Models;

public class Product
{
  [Key]
  public int ProductId { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
  public int Quantity { get; set; }
  public decimal Price { get; set; }
  [ForeignKey("CategoryId")]
  public int CategoryId { get; set; }
  public virtual Category? Category { get; set; }
}