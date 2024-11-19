public class Program
{
  public static void Main(string[] ags)
  {
    GetDateNow();
    string momento = GetTimeNow();
    Console.WriteLine(momento);

    GeDateDay();
  }

  public static void GetDateNow()
  {
    var date = new DateTime(2024, 11, 19, 11, 36, 0);
    var dateOnly = date.Date;
    Console.WriteLine(dateOnly.ToString());
  }

  public static string GetTimeNow()
  {
    return "O momento de tempo atual é " + DateTime.Now;
  }

  public static void GeDateDay()
  {
    var date = new DateTime(2024, 11, 19, 11, 39, 0);
    var dayOnly = date.Day;
    Console.WriteLine(dayOnly.ToString());
  }
}