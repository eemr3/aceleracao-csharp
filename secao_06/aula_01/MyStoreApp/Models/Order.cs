namespace MyStoreApp.Models;

public class Order
{
  public int OderId { get; set; }
  public DateTime OrderDate { get; set; }
  public ICollection<OrderItem>? OrderItems { get; set; }
}