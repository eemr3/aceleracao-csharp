using Customer.DTO;
using Customer.Models;

namespace Customer.Services;

public interface ICustomerService
{
  public Task<CustomerEntity> AddCustomer(CustomerDtoRequest customerDto);
  public Task<IEnumerable<CustomerEntity>> GetCustomers();
  public Task<CustomerEntity> GetCustomerById(int id);
}