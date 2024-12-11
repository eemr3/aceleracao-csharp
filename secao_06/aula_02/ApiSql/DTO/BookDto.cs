using ApiSql.Models;

namespace ApiSql.DTO;

public class BookDTO
{
  public string Title { get; set; }
  public string Description { get; set; }
  public int Year { get; set; }
  public int Pages { get; set; }
  public string Genre { get; set; }
  public AuthorDTO Author { get; set; }
  public PublisherDTO Publisher { get; set; }

}