namespace Order.Models;

public class OrderEntity
{
  public int OrderId { get; set; }

  public int CustomerId { get; set; }
  public DateTime OrderDate { get; set; }
  public decimal Amount { get; set; }
}