using Customer.Models;

namespace Customer.Repositories;

public interface ICustomerRepository
{
  public Task<CustomerEntity> AddCustomer(CustomerEntity customerDto);
  public Task<IEnumerable<CustomerEntity>> GetCustomers();
  public Task<CustomerEntity?> GetCustomerById(int id);
  public Task<CustomerEntity?> GetCustomerByEmail(string email);
}