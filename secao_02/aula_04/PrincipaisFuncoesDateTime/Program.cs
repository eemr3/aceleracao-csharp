public class Program
{
  public static void Main(string[] args)
  {
    AddDays();
    DecreaseDays();
    AddSpecificDay();
    CompareDate();
  }

  public static void AddDays()
  {
    var today = DateTime.Now;
    var duration = new TimeSpan(36, 0, 0, 0);
    var answer = today.Add(duration);

    Console.WriteLine($"Hoje é {today.Day}/{today.Month} - today.DayOfWeek");
    Console.WriteLine($"Daqui a 36 dias será {answer.Day}/{answer.Month} - answer.DayOfWeek");
  }

  public static void DecreaseDays()
  {
    var today = DateTime.Now;
    var duration = new TimeSpan(-36, 0, 0, 0);
    var answer = today.Add(duration);

    Console.WriteLine($"Hoje é {today.Day}/{today.Month} - {today.DayOfWeek}");
    Console.WriteLine($"36 atrás era {answer.Day}/{answer.Month} - {answer.DayOfWeek}");
  }

  public static void AddSpecificDay()
  {
    var today = DateTime.Now;
    var answer = today.AddDays(36);

    Console.WriteLine($"Hoje é {today.Day}/{today.Month} - today.DayOfWeek");
    Console.WriteLine($"Daqui a 36 dias será {answer.Day}/{answer.Month} - answer.DayOfWeek");
  }

  public static void CompareDate()
  {
    DateTime date1 = new DateTime(2010, 9, 1, 5, 0, 0);
    DateTime date2 = new DateTime(2022, 8, 10, 12, 0, 0);

    int result = DateTime.Compare(date1, date2);
    string relationship;

    if (result < 0) relationship = "é anterior à";
    else if (result == 0) relationship = "è o mesmo que";
    else relationship = "è posterior à";

    Console.WriteLine("{0} {1} {2}", date1, relationship, date2);
  }
}