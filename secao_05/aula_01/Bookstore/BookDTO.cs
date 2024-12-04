namespace Bookstore;

public class BookDTO
{
  public string? BookNane { get; set; }
  public string? AuthorName { get; set; }

  public BookDTO(string bookName, string authorName)
  {
    BookNane = bookName;
    AuthorName = authorName;
  }
}