public class Program
{
  public static void Main(string[] args)
  {
    string x = "Trybe";
    string y = "C#";
    Console.WriteLine($"Antes da troca - x = {x} - y = {y}");

    TrocarVariaveis(ref x, ref y);

    Console.WriteLine($"Depois da troca - x = {x} - y = {y}");

    int n1 = 4;
    int n2 = 7;
    Console.WriteLine($"Antes da troca - n1 = {n1} - n2 = {n2}");

    TrocarVariaveis(ref n1, ref n2);

    Console.WriteLine($"Depois da troca - n1 = {n1} - n2 = {n2}");
  }

  public static void TrocarVariaveis<T>(ref T variavelA, ref T variavelB)
  {
    T tempVariavel = variavelA;
    variavelA = variavelB;
    variavelB = tempVariavel;

  }
}