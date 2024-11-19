public class Program
{
  public static void Main()
  {
    SimpleArray();
  }

  public static void SimpleArray()
  {
    int[] myFirstArray = { 1, 5, 8, 9 };
    string[] mySecondArray = { "maçã", "laranja", "uva" };
    double[] myThirdArray = new double[] { 2.4, 5.6 };

    Console.WriteLine(myFirstArray[3]);
    Console.WriteLine(mySecondArray[0]);
    Console.WriteLine(myThirdArray[1]);
    Console.WriteLine(myThirdArray[2]); // Estouro de excessão devido posição não existente no array.
    Console.Write("Será que segou até aqui?");
  }

  public static void MultidimensionalArray()
  {
    // Declaração de um array multidimensional
    int[,] multiDimensionalArray1 = new int[2, 3]; // Terá duas linha e 3 colunas

    // Declaração e inicialização de uma array multidimensional
    int[,] multiDimensionalArray = { { 1, 2, 3 }, { 4, 5, 6 } };// Terá duas linha e 3 colunas

    // O que acabamos de criar é um Array em que todas as colunas possuem o mesmo tamanho, o que significa que todos os Arrays que estão dentro dos elementos do Array inicial possuem o mesmo tamanho.

    //Um array jagged (dentado)
    // Somente instanciamos o array mais externo neste primeiro passo
    // Repare que apenas o primeiro colchetes contém números
    int[][] jaggedArray = new int[4][];

    // Agora precisamos instanciar um novo array para cada posição do array mais externo
    jaggedArray[0] = new int[4] { 6, 6, 6, 6 };
    jaggedArray[1] = new int[3] { 6, 6, 6 };
    jaggedArray[2] = new int[5] { 6, 6, 6, 6, 6 };
    jaggedArray[3] = new int[2] { 6, 6 };
  }
}