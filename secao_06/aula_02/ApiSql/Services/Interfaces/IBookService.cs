using ApiSql.DTO;
using ApiSql.Models;

namespace ApiSql.Services.interfaces;

public interface IBookService
{
  public Task<Book> AddBookAsync(BookDTO bookDto);
  public Book GetBookIdAsync(int bookId);

  public List<Book> GetBooks();
}