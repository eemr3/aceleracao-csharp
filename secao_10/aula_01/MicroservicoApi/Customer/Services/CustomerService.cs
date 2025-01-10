using Customer.DTO;
using Customer.Exceptions;
using Customer.Models;
using Customer.Repositories;

namespace Customer.Services;

public class CustomerService : ICustomerService
{
  private readonly ICustomerRepository _repository;

  public CustomerService(ICustomerRepository repository)
  {
    _repository = repository;
  }

  public async Task<CustomerEntity> AddCustomer(CustomerDtoRequest customerDto)
  {
    var customer = new CustomerEntity
    {
      Name = customerDto.Name,
      Email = customerDto.Email
    };

    var customerExists = await _repository.GetCustomerByEmail(customerDto.Email);


    if (customerExists is not null) throw new ConflictException($"O cliente com o email {customer.Email} já esta cadastrado.");

    var customerAdd = await _repository.AddCustomer(customer);

    return customerAdd;
  }

  public async Task<CustomerEntity> GetCustomerById(int id)
  {
    var customer = await _repository.GetCustomerById(id);

    if (customer is null) throw new KeyNotFoundException($"O cliente com ID {id} não foi encontrado.");

    return customer;
  }

  public async Task<IEnumerable<CustomerEntity>> GetCustomers()
  {
    return await _repository.GetCustomers();
  }
}