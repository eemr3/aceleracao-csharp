using Order.DTO;
using Order.Models;
using Order.Repositories;

namespace Order.Services;

public class OrderService : IOrderService
{
  private readonly IOrderRepository _respository;

  public OrderService(IOrderRepository repository)
  {
    _respository = repository;
  }

  public async Task<OrderEntity> AddOrderAsync(OrderDtoRequest orderDto)
  {
    var orderAdd = await _respository.AddOrderAsync(new OrderEntity
    {
      CustomerId = orderDto.CustomerId,
      OrderDate = orderDto.OrderDate,
      Amount = orderDto.Amount
    });

    return orderAdd;
  }

  public async Task<IEnumerable<OrderEntity>> GetOrderByCustomerIdAsync(int customerId)
  {
    var ordersByCustomer = await _respository.GetOrdersByCustomerIdAsync(customerId);

    if (ordersByCustomer is null) throw new KeyNotFoundException($"Os pedidos do cliente de ID {customerId} não foi encontrado.");

    return ordersByCustomer;
  }

  public async Task<OrderEntity> GetOrderByIdAsync(int orderId)
  {
    var order = await _respository.GetOrderByIdAsync(orderId);

    if (order is null) throw new KeyNotFoundException($"O pedido com ID {orderId} não foi encontrado");

    return order;
  }

  public async Task<IEnumerable<OrderEntity>> GetOrdersdAsync()
  {
    return await _respository.GetOrders();
  }
}