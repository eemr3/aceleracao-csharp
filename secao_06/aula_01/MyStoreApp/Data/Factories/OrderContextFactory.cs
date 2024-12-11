using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyStoreApp.Data.Factories;

public class OrderContextFactory : IDesignTimeDbContextFactory<OrderContext>
{
  public OrderContextFactory() { }
  public OrderContext CreateDbContext(string[] args)
  {

    var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.json")
     .Build();

    var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

    return new OrderContext(optionsBuilder.Options);

  }
}