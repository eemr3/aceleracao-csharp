using ApiSql.DTO;
using ApiSql.Models;
using ApiSql.Repositories;
using ApiSql.Services.interfaces;

namespace ApiSql.Services;

public class BookService : IBookService
{
  private readonly BookRepository _repository;

  public BookService(BookRepository repository)
  {
    _repository = repository;
  }

  public async Task<Book> AddBookAsync(BookDTO bookDto)
  {
    var book = new Book
    {

      Title = bookDto.Title,
      Description = bookDto.Description,
      Year = bookDto.Year,
      Pages = bookDto.Pages,
      Genre = bookDto.Genre,
      Author = new Author
      {
        Name = bookDto.Author.Name,
        Email = bookDto.Author.Email
      },
      Publisher = new Publisher
      {
        Name = bookDto.Publisher.Name
      }

    };

    return await _repository.AddBookAsync(book);
  }

  public Book GetBookIdAsync(int bookId)
  {
    return _repository.GetBookId(bookId);
  }

  public List<Book> GetBooks()
  {
    return _repository.GetBookList();
  }
}