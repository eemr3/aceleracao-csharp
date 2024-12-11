namespace MyStoreApp.Data.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyStoreApp.Data;

public class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
{
  public ProductContextFactory() { }
  public ProductContext CreateDbContext(string[] args)
  {

    var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();
    var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

    return new ProductContext(optionsBuilder.Options);
  }
}