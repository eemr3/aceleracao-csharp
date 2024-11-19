public class Program
{
  public static void Main()
  {
    Console.WriteLine("Informe um número inteiro");
    string? response = Console.ReadLine();
    int number = 0;
    var canConvert = Int32.TryParse(response, out number);

    switch (number)
    {
      case > 0:
        Console.WriteLine("maior que 0");
        break;
      case 0:
        Console.WriteLine("igual a zero");
        break;
      default:
        Console.WriteLine("menor que zero");
        break;
    }

    Console.WriteLine(IdentifyPolygon(number));
    Console.WriteLine(Complexity(number));
  }

  public static string IdentifyPolygon(int sideCount)
  {
    var name = string.Empty;
    switch (sideCount)
    {
      case < 3:
        name = "Não é um polígono";
        break;
      case 3:
        name = "Triângulo";
        break;
      case 4:
        name = "Quadrado";
        break;
      case 5:
        name = "Pentágono";
        break;
      case 6:
        name = "Hexágono";
        break;
      default:
        name = "Polígono não identificado";
        break;
    }

    return name;
  }

  public static string Complexity(int sideCount)
  {
    var complexity = string.Empty;

    switch (sideCount)
    {
      case 3:
      case 4:
      case 5:
        complexity = "Básico";
        break;
      default:
        complexity = "Complexo";
        break;
    }

    return complexity;

  }
}
