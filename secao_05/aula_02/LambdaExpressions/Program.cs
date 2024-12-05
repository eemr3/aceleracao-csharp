public class Car
{
  public string? Brand { get; set; }
  public string? Model { get; set; }
  public float Price { get; set; }
}

public class Category
{
  public string? Name;
  public List<Car>? Cars;
}

class Program
{
  public static void Main(string[] args)
  {
    List<Car> cars = new List<Car>
        {
            new Car { Brand = "Ferrari", Model = "LaFerrari", Price = 7100000 },
            new Car { Brand = "McLaren", Model = "Elva", Price = 8600000 },
            new Car { Brand = "Bentley", Model = "Mulliner Batur", Price = 10200000 },
            new Car { Brand = "Aston Martin", Model = "Valkyrie", Price = 16300000 },
            new Car { Brand = "BMW", Model = "IX", Price = 670000 },
            new Car { Brand = "Bugatti", Model = "Divo", Price = 26000000 },
            new Car { Brand = "Ferrari", Model = "F8 Spider", Price = 5200000 },
            new Car { Brand = "McLaren", Model = "Speedtail", Price = 40000000 },
            new Car { Brand = "Koenigsegg", Model = "Agera", Price = 7500000 },
            new Car { Brand = "Devel", Model = "Sixteen", Price = 79000020 }
        };


    // Operação de Projeção com Select()
    var carSelect = cars.Select(car => new { car.Brand, car.Model });
    // foreach (var car in carSelect)
    // {
    //   Console.WriteLine(car);
    // }

    // Operação de Filtragem com Where()
    var carWhere = cars.Where(car => car.Price > 5200000);

    //   foreach (var car in carWhere)
    //   {
    //     Console.WriteLine($"Marca: {car.Brand} - Modelo: {car.Model} - Preço R$ {car.Price}");
    //   }

    // Operação de Ordenação
    var orderCar = cars.OrderBy(car => car.Price);
    // foreach (var car in orderCar)
    // {
    //   Console.WriteLine($"{car.Brand} {car.Model} - Preço: R$ {car.Price}");
    // }

    // Operação de Quantificação  com All() e Any()
    bool resultadoAll = cars.All(car => car.Price > 15000000);
    // Console.WriteLine($"Todos os carros custam mais de 15M? {resultadoAll}");

    bool resultadoAny = cars.Any(car => car.Price > 15000000);
    // Console.WriteLine($"Algum carro custa mais de 15M? {resultadoAny}");

    // Operação de agrupamento com GroupBy
    var carsByBrand = cars.GroupBy(car => car.Brand);

    foreach (var carByBrand in carsByBrand)
    {
      Console.WriteLine(carByBrand.Key);
      foreach (var car in carByBrand)
      {
        Console.WriteLine($"\t {car.Model} - Preço R$ {car.Price}");
      }
    }


  }


}