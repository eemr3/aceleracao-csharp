public class Program
{
  public static void Main(string[] args)
  {
    try
    {
      InitialGreeting();
      int year = Convert.ToInt32(Console.ReadLine());
      var age = CalculateAgeByYear(year);

      Console.WriteLine("A sua idade é: " + age + " anos!");
      ValidateComingOfAge(age);

    }
    catch (AccessViolationException err)
    {
      Console.WriteLine("Error no acesso: " + err.Message);

    }
    catch (Exception err)
    {
      Console.WriteLine("Error: " + err.Message);
    }
    finally
    {
      Console.WriteLine("Software finalizado!");
    }

  }

  public static void InitialGreeting()
  {
    Console.WriteLine("Controle de acesso!");
    Console.WriteLine("Digite o ano de nascimento: ");
  }

  public static int CalculateAgeByYear(int year)
  {
    int age = DateTime.Now.Year - year;

    return age;
  }

  public static void ValidateComingOfAge(int age)
  {

    if (age < 18)
    {
      throw new AccessViolationException("Mernor de idade!");
    }

  }
}