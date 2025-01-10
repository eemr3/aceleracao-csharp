using System.ComponentModel.DataAnnotations;

namespace Order.DTO;

public class OrderDtoRequest
{
  [Range(1, int.MaxValue, ErrorMessage = "O ID do cliente não pode ser negativo.")]
  public int CustomerId { get; set; }

  [Required(ErrorMessage = "A data do pedido é obrigatório")]
  public string OrderDate { get; set; } = null!;

  [Required(ErrorMessage = "O valor do pedido é obrigatório.")]
  [Range(1, int.MaxValue, ErrorMessage = "O valor do pedido não pode ser negativo.")]
  public decimal Amount { get; set; }
}