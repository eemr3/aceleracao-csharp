public class Program
{
  public static void Main()
  {
    // WhileStructure();

    // DoWhileStructure();

    // ForStructure();

    // ForEachStructure();

    // BreakInstruction();

    // ContinueInstruction();

    int[] numbers = new int[] { 1, 2, 3, 5, 8 };

    Console.WriteLine(IndexOf(numbers, 5));

    Console.WriteLine(CountEvenNumbers(numbers));
  }

  public static void WhileStructure()
  {
    int count = 0;


    while (count < 10)
    {

      Console.WriteLine("While contando " + count);
      count += 1;
    }

  }
  public static void DoWhileStructure()
  {
    int count = 0;


    do
    {

      Console.WriteLine("Do While contando " + count);
      count += 1;
    } while (count < 10);

  }

  public static void ForStructure()
  {
    for (int count = 0; count < 3; count += 1)
    {
      Console.WriteLine("For - numero: " + count);
    }
  }

  public static void ForEachStructure()
  {
    string[] names = new string[] { "Hulk", "Thor", "Loki" };

    foreach (string name in names)
    {
      Console.WriteLine("ForEach -" + " " + name);
    }
  }

  public static void BreakInstruction()
  {
    string[] teachers = new string[] { "Joel", "Tess", "Marlene" };
    string[] students = new string[] { "Ellie", "Joel", "Abby" };
    foreach (var teacher in teachers)
    {
      Console.WriteLine("Professor: " + teacher + ". Estudante:");
      foreach (var student in students)
      {
        if (teacher == student)
          break;
        Console.WriteLine(student);
      }
    }
  }
  public static void ContinueInstruction()
  {
    int[] votes = new int[] { 1, 3, 5, 4, 1, 3, 1, 2 };
    var count = 0;
    foreach (var vote in votes)
    {
      if (vote > 3)
        continue;
      count++;
    }
    Console.WriteLine(count + " votos válidos");
  }

  public static int IndexOf(int[] numbers, int value)
  {
    var position = -1;

    for (int i = 0; i < numbers.Count(); i++)
    {
      if (numbers[i] == value)
      {
        position = i;
        break;
      }
    }

    return position;
  }

  public static int CountEvenNumbers(int[] numbers)
  {
    var count = 0;

    foreach (var number in numbers)
    {
      if (number % 2 != 0) continue;
      count++;
    }

    return count;
  }
}