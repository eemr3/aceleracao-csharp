using System.ComponentModel.DataAnnotations;

namespace Order.DTO;

public class OrderDtoRequest
{
  [Range(1, int.MaxValue, ErrorMessage = "O ID do cliente não pode ser negativo.")]
  public int CustomerId { get; set; }
  public DateTime OrderDate { get; set; }

  [Required(ErrorMessage = "O valor do pedido é obrigatório.")]
  [Range(1, int.MaxValue, ErrorMessage = "O valor do pedido não pode ser negativo.")]
  public decimal Amount { get; set; }
}