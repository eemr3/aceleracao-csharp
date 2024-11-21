namespace Movie
{
  public class Program
  {
    public static void Main(string[] args)
    {
      try
      {
        Movie movieA = new Movie("Matrix", "Ficção científica");
        Movie movieB = new Movie("Senhor dos Anéis", "Fantasia");

        Console.WriteLine(movieA.Title);
        Console.WriteLine(movieB.Title);

        Movie movieC = new Movie("Matrix2", "Ficção"); // provoca uma exceção no momento de instanciar

        movieA.Category = "Ficção"; // provoca uma exceção ao modificar


      }
      catch (Exception ex)
      {

        Console.WriteLine($"Error: {ex.Message}");
      }
    }
  }
}