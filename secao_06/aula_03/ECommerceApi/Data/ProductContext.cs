using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data;

public class ProductContext : DbContext
{
  public DbSet<Product>? Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=e-commerce;User=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;");
  }
}