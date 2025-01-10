using Microsoft.EntityFrameworkCore;
using Order.Data;
using Order.Models;

namespace Order.Repositories;

public class OrderRepository : IOrderRepository
{
  private readonly AppDBContext _context;

  public OrderRepository(AppDBContext context)
  {
    _context = context;
  }

  public async Task<OrderEntity> AddOrderAsync(OrderEntity order)
  {
    var orderAdd = await _context.AddAsync(order);

    return orderAdd.Entity;
  }

  public async Task<IEnumerable<OrderEntity>> GetOrdersByCustomerIdAsync(int customerId)
  {
    var orders = await _context.Orders.Where(order => order.CustomerId.Equals(customerId)).ToListAsync();

    if (orders is null) throw new KeyNotFoundException($"Os pedidos do cliente de ID {customerId} não foi encontrado.");

    return orders;
  }

  public async Task<OrderEntity> GetOrderByIdAsync(int orderId)
  {
    var order = await _context.Orders.FindAsync(orderId);

    if (order is null) throw new KeyNotFoundException($"O pedido com ID {orderId} não foi encontrado");

    return order;
  }

  public async Task<IEnumerable<OrderEntity>> GetOrders()
  {
    return await _context.Orders.ToListAsync();
  }
}