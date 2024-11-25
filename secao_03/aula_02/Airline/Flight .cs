namespace Airline
{
  public class Flight
  {
    private FlightType? _flightType;
    private IAirplane? _airplane;
    public IAirplane? Airplane
    {
      get
      {
        return _airplane;
      }
      set
      {
        if (value!.GetType() == typeof(PassengerAirplane))
        {
          _flightType = FlightType.Commercial;
        }
        else
        {
          _flightType = FlightType.Cargo;
        }

        _airplane = value;
      }
    }
    public string FlightId { get; set; }
    public double Distence;


    public Flight(string flightId, double distance)
    {
      FlightId = flightId;
      Distence = distance;
    }


    public void Load()
    {
      if (_airplane is null) throw new InvalidDataException("Airplane not defined");
      if (_flightType == FlightType.Cargo) throw new ArgumentException("Cargo flights must specify a load weight");

      IPassengerAirplane myAirplane = (IPassengerAirplane)_airplane;
      myAirplane.Load();
    }

    public void Load(double weight)
    {
      if (_airplane is null) throw new InvalidDataException("Airplane not defined");
      if (_flightType == FlightType.Commercial) throw new ArgumentException("Cargo flights must specify a load weight");

      ICargoAirplane myAirplane = (ICargoAirplane)_airplane;
      myAirplane.Load(weight);

    }
    public double CalculateCost()
    {
      if (_airplane is null) throw new InvalidDataException("Airplane not defined");
      return 20 * Distence + _airplane.CalculateCost();
    }
  }
}