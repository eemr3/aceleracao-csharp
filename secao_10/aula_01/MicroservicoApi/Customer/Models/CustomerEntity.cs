using System.ComponentModel.DataAnnotations;

namespace Customer.Models;

public class CustomerEntity
{
  public int CustomerId { get; set; }

  [Required]
  public string Name { get; set; } = null!;
  [Required]
  public string Email { get; set; } = null!;

}