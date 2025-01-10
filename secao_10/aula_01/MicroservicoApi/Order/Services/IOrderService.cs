using Order.DTO;
using Order.Models;

namespace Order.Services;

public interface IOrderService
{
  public Task<OrderEntity> AddOrderAsync(OrderDtoRequest orderDto);
  public Task<IEnumerable<OrderEntity>> GetOrderByCustomerIdAsync(int customerId);
  public Task<OrderEntity> GetOrderByIdAsync(int orderId);
  public Task<IEnumerable<OrderEntity>> GetOrdersAsync();
}