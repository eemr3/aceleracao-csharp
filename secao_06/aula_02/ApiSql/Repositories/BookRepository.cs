using ApiSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Repositories;

public class BookRepository
{
  private readonly BookContext _context;

  public BookRepository(BookContext context)
  {
    _context = context;
  }

  public List<Book> GetBookList()
  {
    var books = _context.Books.ToList();

    return books;
  }

  public Book GetBookId(int id)
  {
    return _context.Books.Where(e => e.BookId == id)
          .Include(e => e.Author)
          .Include(e => e.Publisher)
          .First();
  }
  public async Task<Book> AddBookAsync(Book book)
  {
    if (book == null)
      throw new ArgumentNullException(nameof(book));

    await _context.Books.AddAsync(book);
    await _context.SaveChangesAsync();

    return book;
  }
}