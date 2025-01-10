using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data;

public class AppDBContext : DbContext
{
  public DbSet<Product> Products { get; set; } = null!;

  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>(entity =>
    {
      entity.ToTable("products");
      entity.HasKey(prod => prod.Id);
      entity.Property(prod => prod.Name).HasColumnName("name");
      entity.Property(prod => prod.Brand).HasColumnName("brand");
      entity.Property(prod => prod.Price)
          .HasColumnName("price")
          .HasColumnType("decimal(18,2)");
    });

    base.OnModelCreating(modelBuilder);
  }
}