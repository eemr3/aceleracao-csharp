using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Data;

public class DatabaseContext : DbContext, IDatabaseContext
{
  public DbSet<User> Users { get; set; } = null!;

  public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

  public async Task<int> SaveChangesAsync()
  {
    return await base.SaveChangesAsync();
  }
}