using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data;

public class AuthDbContext : DbContext
{
  public DbSet<User> Users { get; set; } = null!;

  public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>(entity =>
    {
      entity.HasKey(u => u.Id);
      entity.HasIndex(u => u.Email).IsUnique();
    });

    base.OnModelCreating(modelBuilder);
  }
}