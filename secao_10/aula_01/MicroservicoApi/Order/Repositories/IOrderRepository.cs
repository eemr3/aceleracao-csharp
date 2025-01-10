using Order.Models;

namespace Order.Repositories;

public interface IOrderRepository
{
  public Task<OrderEntity> AddOrderAsync(OrderEntity order);
  public Task<OrderEntity?> GetOrderByIdAsync(int orderId);
  public Task<IEnumerable<OrderEntity>?> GetOrdersByCustomerIdAsync(int customerId);
  public Task<IEnumerable<OrderEntity>> GetOrders();
}