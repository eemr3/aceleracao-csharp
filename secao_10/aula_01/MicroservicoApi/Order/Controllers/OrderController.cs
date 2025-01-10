using Microsoft.AspNetCore.Mvc;
using Order.DTO;
using Order.Filters;
using Order.Services;

namespace Order.Controllers;

[ApiController]
[Route("api/orders")]
[TypeFilter(typeof(CustomExceptionsFilter))]
public class OrderController : ControllerBase
{
  private readonly IOrderService _service;

  public OrderController(IOrderService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<IActionResult> AddOrder([FromBody] OrderDtoRequest orderDto)
  {
    var orderAdd = await _service.AddOrderAsync(orderDto);

    return CreatedAtAction(nameof(GetOrderById), new { orderId = orderAdd.OrderId }, orderAdd);
  }

  [HttpGet]
  public async Task<IActionResult> GetOrders()
  {
    var orders = await _service.GetOrdersAsync();

    return Ok(orders);
  }

  [HttpGet("{customerId}/customer")]
  public async Task<IActionResult> GetOredesByCustomer(int customerId)
  {
    var orders = await _service.GetOrderByCustomerIdAsync(customerId);

    return Ok(orders);
  }

  [HttpGet("{orderId}")]
  public async Task<IActionResult> GetOrderById(int orderId)
  {
    var order = await _service.GetOrderByIdAsync(orderId);

    return Ok(order);
  }
}