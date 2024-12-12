namespace ApiSql.DTO;

public class BookDTO
{
  public int BookId { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public int Year { get; set; }
  public int Pages { get; set; }
  public string? Genre { get; set; }
  public string? AuthorName { get; set; }
  public string? PublisherName { get; set; }

}