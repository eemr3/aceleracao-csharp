using NestedQueriesProjection;

class Program
{
  public static void Main(string[] args)
  {
    List<Category> categoryCars = new List<Category>()
    {
        new Category { Name = "Luxury", Cars = new List<Car> {
                    new Car { Brand = "Ferrari", Model = "LaFerrari", Price = 7100000 },
                    new Car { Brand = "McLaren", Model = "Elva", Price = 8600000 },
                    new Car { Brand = "Bentley", Model = "Mulliner Batur", Price = 10200000 },
                    new Car { Brand = "Aston Martin", Model = "Valkyrie", Price = 16300000 },
                    new Car { Brand = "BMW", Model = "IX", Price = 670000 }
                }},
        new Category { Name = "Sport", Cars = new List<Car> {
                    new Car { Brand = "Bugatti", Model = "Divo", Price = 26000000 },
                    new Car { Brand = "Ferrari", Model = "F8 Spider", Price = 5200000 },
                    new Car { Brand = "McLaren", Model = "Speedtail", Price = 40000000 },
                    new Car { Brand = "Koenigsegg", Model = "Agera", Price = 7500000 },
                    new Car { Brand = "Devel", Model = "Sixteen", Price = 79000020 }
                }}
    };

    var carsSport = from categoryCar in categoryCars
                    where categoryCar.Name == "Sport"
                    select new
                    {
                      categoryCar.Name,
                      Cars = from car in categoryCar.Cars
                             where car.Price > 30000000
                             select car
                    };

    foreach (var carSportOver30M in carsSport)
    {
      Console.WriteLine("Categoria: " + carSportOver30M.Name);
      foreach (var car in carSportOver30M.Cars!)
      {
        Console.WriteLine($"\t {car.Brand} {car.Model} - Preço: R$ {car.Price}");
      }
    }
  }
}
