namespace Airline
{
  public class PassengerAirplane : Airplane, IPassengerAirplane
  {
    private int PassengerCapacity { get; set; }
    private int PassengerQuantity = 0;

    public PassengerAirplane(string prefix, int passengerCapacity) : base(prefix)
    {
      PassengerCapacity = passengerCapacity;
    }

    public void Load()
    {
      if (PassengerQuantity == PassengerCapacity)
      {
        throw new ArgumentException("No seats left");
      }

      PassengerQuantity += 1;
    }

    public override double CalculateCost()
    {
      return base.CalculateStandardCost() + 90 * PassengerQuantity;
    }
  }
}