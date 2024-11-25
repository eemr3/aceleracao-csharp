namespace Airline
{
  public class CargoAirplane : Airplane, ICargoAirplane
  {
    private double Payload { get; set; }
    private double LoadedWeight { get; set; }
    public CargoAirplane(string prefix, double payload) : base(prefix)
    {
      Payload = payload;
    }

    public void Load(double weight)
    {
      if ((LoadedWeight + weight) > Payload)
      {
        throw new ArgumentException("Payload achieved");
      }

      LoadedWeight += weight;
    }

    public override double CalculateCost()
    {
      return CalculateStandardCost() + 35 * LoadedWeight;
    }
  }
}