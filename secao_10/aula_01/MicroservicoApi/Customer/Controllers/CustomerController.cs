using Customer.DTO;
using Customer.Filters;
using Customer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers;

[ApiController]
[Route("api/customers")]
[TypeFilter(typeof(CustomExceptionsFilter))]
public class CustomerController : ControllerBase
{
  private readonly ICustomerService _service;

  public CustomerController(ICustomerService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<IActionResult> AddCustomer([FromBody] CustomerDtoRequest customer)
  {
    var customerAdd = await _service.AddCustomer(customer);

    return Created("", customerAdd);
  }

  [HttpGet]
  public async Task<IActionResult> GetCustomers()
  {
    var customers = await _service.GetCustomers();

    return Ok(customers);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetCustomerById(int id)
  {
    var customer = await _service.GetCustomerById(id);

    return Ok(customer);
  }
}