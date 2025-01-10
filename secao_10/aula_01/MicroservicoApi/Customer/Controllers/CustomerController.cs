using Customer.DTO;
using Customer.Filters;
using Customer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers;

[ApiController]
[Route("customers")]
[TypeFilter(typeof(CustomExceptionsFilter))]
public class CustomerController : ControllerBase
{
  private readonly ICustomerRepository _repository;

  public CustomerController(ICustomerRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  public async Task<IActionResult> AddCustomer([FromBody] CustomerDtoRequest customer)
  {
    var customerAdd = await _repository.AddCustomer(customer);

    return Created("", customerAdd);
  }

  [HttpGet]
  public async Task<IActionResult> GetCustomers()
  {
    var customers = await _repository.GetCustomers();

    return Ok(customers);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetCustomerById(int id)
  {
    var customer = await _repository.GetCustomerById(id);

    return Ok(customer);
  }
}