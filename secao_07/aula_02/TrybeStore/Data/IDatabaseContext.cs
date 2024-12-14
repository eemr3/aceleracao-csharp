using Microsoft.EntityFrameworkCore;
using TrybeStore.Models;

namespace TrybeStore.Data;

public interface IDatabaseContext
{
  DbSet<Product> Products { get; set; }
  DbSet<Category> Categories { get; set; }

  public Task<int> SaveChangesAsync();
}