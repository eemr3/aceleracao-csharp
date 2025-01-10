using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data;

public class AppDBContext : DbContext
{
  public DbSet<User> Users { get; set; } = null!;

  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>(entity =>
    {
      entity.ToTable("users");
      entity.HasKey(user => user.UserId);
      entity.Property(user => user.UserId).HasColumnName("user_id");
      entity.Property(user => user.Name).HasColumnName("name");
      entity.Property(user => user.Email).HasColumnName("email");
      entity.HasIndex(user => user.Email).IsUnique();
      entity.Property(user => user.PasswordHash).HasColumnName("password_hash");
      entity.Property(user => user.Role).HasColumnName("role");
    });

    base.OnModelCreating(modelBuilder);
  }
}