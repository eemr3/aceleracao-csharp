public class Program
{
  public static void Main(string[] args)
  {
    InitialGreeting();
    int year = Convert.ToInt32(Console.ReadLine());
    var age = CalculateAgeByYear(year);

    Console.WriteLine("A sua idade é: " + age + " anos!");
    var isAccsess = ValidateComingOfAge(age);

    if (isAccsess)
    {
      Console.WriteLine("Você pose entrar no recinto!");
    }
    else
    {
      Console.WriteLine("Você é menor de idade. Acesso negado!");
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

  public static bool ValidateComingOfAge(int age)
  {
    bool isValid = age >= 18;

    return isValid;
  }
}