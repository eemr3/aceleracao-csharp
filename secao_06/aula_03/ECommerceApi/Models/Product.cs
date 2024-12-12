using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Models;

public class Product
{
  public int ProductId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }
  public int Qauntity { get; set; }
  public string ImageUrl { get; set; }
  [ForeignKey("CategoryId")]
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; }

}