using Customer.DTO;
using Customer.Models;

namespace Customer.Repositories;

public interface ICustomerRepository
{
  public Task<CustomerEntity> AddCustomer(CustomerDtoRequest customerDto);
  public Task<IEnumerable<CustomerEntity>> GetCustomers();
  public Task<CustomerEntity> GetCustomerById(int id);
}