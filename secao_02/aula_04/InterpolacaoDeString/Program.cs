public class Program
{
  public static void Main(string[] args)
  {
    string name = getName();

    Console.WriteLine($"O seu nome é {name}");
  }

  public static string getName()
  {
    Console.WriteLine("Qual o seu nome? ");
    string? name = Console.ReadLine();

    return name ?? "Nome desconhecido";
  }
}