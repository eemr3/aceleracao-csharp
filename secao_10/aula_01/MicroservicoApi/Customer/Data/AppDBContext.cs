using Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data;

public class AppDBContext : DbContext
{
  DbSet<CustomerEntity> Customers { get; set; } = null!;

  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<CustomerEntity>(entity =>
    {
      entity.HasKey(cust => cust.CustomerId);
      entity.ToTable("customers");
      entity.Property(cust => cust.CustomerId).HasColumnName("customer_id");
      entity.Property(cust => cust.Name).HasColumnName("name");
      entity.Property(cust => cust.Email).HasColumnName("email");
    });

    base.OnModelCreating(modelBuilder);
  }
}