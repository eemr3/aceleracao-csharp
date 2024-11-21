namespace Bank
{
  public class Client
  {
    public string Name { get; set; }
    public bool Actrive = true;
    public decimal Balance { get; set; }

    public Client(string name, decimal balance)
    {
      Name = name;
      Balance = balance;
    }
  }
}