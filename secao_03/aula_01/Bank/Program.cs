using Bank;
namespace Bank
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Client client1 = new Client("Pedro", 100.5m); // Forma padrão de instancia uma class
      // Client client1 = new("Pedro", 100.5m); // Forma simplificada para instanciar uma class já que foi tipada com a classs

      Console.WriteLine(client1.Name);
      Console.WriteLine(client1.Balance);

    }
  }
}