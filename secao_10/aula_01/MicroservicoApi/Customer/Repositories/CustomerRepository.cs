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

  public async Task<CustomerEntity> AddCustomer(CustomerDtoRequest customerDto)
  {
    var customer = await _context.Customers.FirstOrDefaultAsync(cust => cust.Email.Equals(customerDto.Email));

    if (customer is not null) throw new ConflictException($"O cliente com o email {customerDto.Email} já esta cadastrado.");

    var customerAdd = _context.Customers.Add(new CustomerEntity
    {
      Name = customerDto.Name,
      Email = customerDto.Email
    });

    await _context.SaveChangesAsync();

    return customerAdd.Entity;
  }

  public async Task<CustomerEntity> GetCustomerById(int id)
  {
    var customer = await _context.Customers.FindAsync(id);

    if (customer is null) throw new KeyNotFoundException($"O cliente com ID {id} não foi encontrado.");

    return customer;
  }

  public async Task<IEnumerable<CustomerEntity>> GetCustomers()
  {
    return await _context.Customers.ToListAsync();
  }
}