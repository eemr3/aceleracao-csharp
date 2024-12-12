using ApiSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Repositories;

public class BookContext : DbContext
{
  public DbSet<Book> Books { get; set; } = null!;
  public DbSet<Author> Authors { get; set; } = null!;
  public DbSet<Publisher> Publishers { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    string connectionString = "Server=127.0.0.1;Database=bookstore;User=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";
    optionsBuilder.UseSqlServer(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Definição da relação com Author
    modelBuilder.Entity<Book>()
      .HasOne(b => b.Author)
      .WithMany(a => a.Books)
      .HasForeignKey(b => b.AuthorId);

    // Definição da relação com Publisher
    modelBuilder.Entity<Book>()
      .HasOne(b => b.Publisher)
      .WithMany(p => p.Books)
      .HasForeignKey(b => b.PublisherId);

  }
}