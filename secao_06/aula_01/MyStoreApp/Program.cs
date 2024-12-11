using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStoreApp.Data;
using MyStoreApp.Data.Factories;

class Program
{
  public static void Main(string[] args)
  {

    var serviceProvider = new ServiceCollection()
         .AddSingleton<IDesignTimeDbContextFactory<ProductContext>, ProductContextFactory>()
         .AddSingleton<IDesignTimeDbContextFactory<OrderContext>, OrderContextFactory>()
         .BuildServiceProvider();


    var productContextFactory = serviceProvider.GetService<IDesignTimeDbContextFactory<ProductContext>>();
    if (productContextFactory == null)
    {
      Console.WriteLine("Erro: Factory para ProductContext não encontrada.");
      return;
    }

    using (var productContext = productContextFactory.CreateDbContext(args))
    {
      productContext?.Database.EnsureCreated();

    }

    var orderContextFactory = serviceProvider.GetService<IDesignTimeDbContextFactory<OrderContext>>();
    if (orderContextFactory == null)
    {
      Console.WriteLine("Erro: Factory para ProductContext não encontrada.");
      return;
    }

    using (var orderContext = orderContextFactory.CreateDbContext(args))
    {
      orderContext?.Database.EnsureCreated();
    }

    Console.WriteLine("Banco de dados criado com sucesso!");
  }
}
