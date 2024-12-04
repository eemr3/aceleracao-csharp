namespace Bookstore;

public class Book
{
  public string? Title { get; set; }
  public int Price { get; set; }
  public int PublishYear { get; set; }

  public Book(string title, int price, int publishYear)
  {
    Title = title;
    Price = price;
    PublishYear = publishYear;
  }
}