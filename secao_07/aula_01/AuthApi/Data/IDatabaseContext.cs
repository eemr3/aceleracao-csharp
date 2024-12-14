using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Data;

public interface IDatabaseContext
{
  public DbSet<User> Users { get; set; }

  public Task<int> SaveChangesAsync();
}