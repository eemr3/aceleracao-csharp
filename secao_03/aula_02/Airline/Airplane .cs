namespace Airline
{
  public abstract class Airplane : IAirplane
  {
    public string Prefix { get; set; }
    public Airplane(string prefix)
    {
      Prefix = prefix;
    }

    public abstract double CalculateCost();
    public double CalculateStandardCost()
    {
      return 1352.45;
    }
  }
}