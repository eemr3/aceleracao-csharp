using System.Globalization;
namespace Airline
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CultureInfo culturaBR = new CultureInfo("pt-BR");

      PassengerAirplane embraer = new PassengerAirplane("PR-ABC", 110);
      CargoAirplane boeing = new CargoAirplane("PT-DEF", 88000);

      Flight flightA = new Flight("001", 500);
      Flight flightB = new Flight("002", 200);

      flightA.Airplane = embraer;
      flightB.Airplane = boeing;

      flightA.Load();
      flightB.Load(500);

      Console.WriteLine($"Aeronave de prefíxo - {flightA.Airplane.Prefix} com o custo do voo em {flightA.CalculateCost().ToString("C", culturaBR)}");

      Console.WriteLine($"Aeronave de prefíxo - {flightB.Airplane.Prefix} com o custo do voo em {flightB.CalculateCost().ToString("C", culturaBR)}");
    }
  }
}