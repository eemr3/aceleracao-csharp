using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data;

public class CatalogDbContext : DbContext
{
  public DbSet<Product> Products { get; set; } = null!;
  public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>(entity =>
    {
      entity.HasKey(prod => prod.Id);
      entity.Property(prod => prod.Price).HasColumnType("decimal(18,2)");
    });

    base.OnModelCreating(modelBuilder);
  }

}