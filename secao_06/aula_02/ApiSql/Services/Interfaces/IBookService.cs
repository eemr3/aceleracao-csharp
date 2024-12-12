using ApiSql.DTO;
using ApiSql.Models;

namespace ApiSql.Services.interfaces;

public interface IBookService
{
  public Task<Book> AddBookAsync(Book bookDto);
  public Task<BookDTO> GetBookIdAsync(int bookId);

  public Task<IEnumerable<BookDTO>> GetBooks();
}