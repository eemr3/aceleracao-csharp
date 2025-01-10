using Microsoft.EntityFrameworkCore;
using Order.Models;

namespace Order.Data;

public class AppDBContext : DbContext
{
  public DbSet<OrderEntity> Orders { get; set; } = null!;

  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<OrderEntity>(entity =>
    {
      entity.ToTable("orders");
      entity.HasKey(order => order.OrderId);
      entity.Property(order => order.OrderId).HasColumnName("order_id");
      entity.Property(order => order.CustomerId).HasColumnName("customer_id");
      entity.Property(order => order.Amount).HasColumnName("amount");
      entity.Property(order => order.Amount).HasColumnType("numeric(10,2)");
      entity.Property(order => order.OrderDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
    });

    base.OnModelCreating(modelBuilder);
  }
}