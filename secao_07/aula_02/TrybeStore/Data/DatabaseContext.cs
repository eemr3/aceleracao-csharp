using Microsoft.EntityFrameworkCore;
using TrybeStore.Models;

namespace TrybeStore.Data;

public class DatabaseContext : DbContext, IDatabaseContext
{

  public DbSet<Product> Products { get; set; } = null!;
  public DbSet<Category> Categories { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;

  public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

  public async Task<int> SaveChangesAsync()
  {
    return await base.SaveChangesAsync();
  }
}