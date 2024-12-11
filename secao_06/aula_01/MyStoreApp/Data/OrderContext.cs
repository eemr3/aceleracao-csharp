namespace MyStoreApp.Data;
using Microsoft.EntityFrameworkCore;
using MyStoreApp.Models;

public class OrderContext : DbContext
{


  public DbSet<Order>? Orders { get; set; }
  public DbSet<OrderItem>? OrderItems { get; set; }

  public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Order>().HasKey(o => o.OderId);

    modelBuilder.Entity<OrderItem>().HasKey(oi => oi.OrderItemId);

    base.OnModelCreating(modelBuilder);
  }
}