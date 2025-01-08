using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data;
public class ContactDbContext : DbContext
{
  public DbSet<Contact> Contacts { get; set; } = null!;

  public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Contact>().HasKey(c => c.ContactId);
    base.OnModelCreating(modelBuilder);
  }
}