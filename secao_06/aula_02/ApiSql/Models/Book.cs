using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSql.Models;

public class Book
{
  [Key]
  public int BookId { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public string? Genre { get; set; }
  public int Year { get; set; }
  public int Pages { get; set; }
  [ForeignKey("AuthorId")]
  public int? AuthorId { get; set; }
  public virtual Author? Author { get; set; }
  [ForeignKey("PublisherId")]
  public int? PublisherId { get; set; }
  public virtual Publisher? Publisher { get; set; }
}