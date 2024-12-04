namespace Bookstore;

public class Book
{
  public string? Title { get; set; }
  public int Price { get; set; }
  public int PublishYear { get; set; }
  public int AuthorId { get; set; }

  public Book(string title, int price, int publishYear, int authorId)
  {
    Title = title;
    Price = price;
    PublishYear = publishYear;
    AuthorId = authorId;
  }
}