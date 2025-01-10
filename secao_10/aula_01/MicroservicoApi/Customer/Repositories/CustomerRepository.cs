using Customer.Data;
using Customer.DTO;
using Customer.Exceptions;
using Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repositories;

public class CustomerRepository : ICustomerRepository
{
  private readonly AppDBContext _context;

  public CustomerRepository(AppDBContext context)
  {
    _context = context;
  }

  public async Task<CustomerEntity> AddCustomer(CustomerEntity customer)
  {
    var customerAdd = _context.Customers.Add(customer);

    await _context.SaveChangesAsync();

    return customerAdd.Entity;
  }

  public async Task<CustomerEntity?> GetCustomerById(int id)
  {
    var customer = await _context.Customers.FindAsync(id);

    if (customer is null) return null;

    return customer;
  }

  public async Task<CustomerEntity?> GetCustomerByEmail(string email)
  {
    var customer = await _context.Customers.FirstOrDefaultAsync(cust => cust.Email.Equals(email));

    if (customer is null) return null;

    return customer;
  }

  public async Task<IEnumerable<CustomerEntity>> GetCustomers()
  {
    return await _context.Customers.ToListAsync();
  }
}