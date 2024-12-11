namespace ProjetoSql.Models;
using Microsoft.EntityFrameworkCore;
public class StudentContext : DbContext
{
  public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

  public StudentContext() { }
  public DbSet<Student> Students { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      var connectionString = "Server=127.0.0.1;Database=trybe_db;User=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

      optionsBuilder.UseSqlServer(connectionString);
    }
  }
}