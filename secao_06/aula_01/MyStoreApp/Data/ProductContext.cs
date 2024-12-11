using Microsoft.EntityFrameworkCore;
namespace MyStoreApp.Data;
using MyStoreApp.Models;

public class ProductContext : DbContext
{

  public DbSet<Product>? Products { get; set; }
  public DbSet<Category>? Categories { get; set; }

  public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
    base.OnModelCreating(modelBuilder);
  }
}

