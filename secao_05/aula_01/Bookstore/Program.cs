namespace Bookstore;

class Program
{
  public static void Main(string[] args)
  {

    // Trabalhando o LINQ "Language-Integrated Query"
    var books = new List<Book>(){
      new Book("Capitães da Areia", 39, 1937, 2),
      new Book("Água Viva", 32, 1973, 1),
      new Book("A hora da Estrela", 35, 1977, 1),
      new Book("Cacau", 25, 1933, 2),
    };

    var authors = new List<Author>(){
      new Author(1, "Clarice Lispector"),
      new Author(2, "Jorge Amado")
    };

    var booksBefre1970 = from book in books where book.PublishYear < 1970 select book.Title;

    Console.WriteLine($"Livro(s) lançado(s) antes do ano 1970:");
    foreach (var book in booksBefre1970)
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

    Console.WriteLine("-------------");

    var bookDto = from book in books
                  from author in authors
                  where book.AuthorId == author.Id
                  orderby author.Name
                  select new BookDTO(book.Title!, author.Name!);

    foreach (var book in bookDto)
    {
      Console.WriteLine($"{book.BookNane} - {book.AuthorName}");
    }
  }

}