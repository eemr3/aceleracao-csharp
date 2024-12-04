namespace Bookstore;

class Program
{
  public static void Main(string[] args)
  {

    // Trabalhando o LINQ "Language-Integrated Query"
    var books = new List<Book>(){
      new Book("The Count of Monte Cristo", 39, 2002),
      new Book("Brave new World ", 32, 1932),
      new Book("The Hobbit", 35, 2011),
      new Book("Pan's Labyrinth: The Labyrinth of the Faun", 25, 2019),
      new Book("Throne of Glass", 29, 2013)
    };

    var booksBefre2000 = from book in books where book.PublishYear < 2000 select book.Title;

    Console.WriteLine($"Livro(s) lançado(s) antes do ano 2000:");
    foreach (var book in booksBefre2000)
    {
      Console.WriteLine(book);
    }

    Console.WriteLine("-------------");
    var booksPriceAfter30 = from book in books where book.Price > 30 select book.Title;


    Console.WriteLine("Livro(s) com preço acima de R$ 30,00");
    foreach (var book in booksPriceAfter30)
    {
      Console.WriteLine(book);
    }
  }
}