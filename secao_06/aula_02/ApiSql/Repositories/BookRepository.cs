using ApiSql.DTO;
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

  public async Task<IEnumerable<BookDTO>> GetBookList()
  {
    var books = await _context.Books
        .Include(b => b.Author)
        .Include(b => b.Publisher)
        .ToListAsync();

    var response = books.Select(book => new BookDTO
    {
      BookId = book.BookId,
      Title = book.Title,
      Description = book.Description,
      Year = book.Year,
      Pages = book.Pages,
      Genre = book.Genre,
      AuthorName = book.Author?.Name,
      PublisherName = book.Publisher?.Name
    });

    return response;
  }

  public async Task<BookDTO> GetBookId(int id)
  {
    var book = await _context.Books.Include(b => b.Author)
        .Include(b => b.Publisher)
        .Where(b => b.BookId == id)
        .FirstOrDefaultAsync();

    if (book == null) throw new KeyNotFoundException($"Book with ID {id} not found!");

    return new BookDTO
    {
      BookId = book.BookId,
      Title = book.Title,
      Description = book.Description,
      Year = book.Year,
      Genre = book.Genre,
      Pages = book.Pages,
      AuthorName = book.Author?.Name,
      PublisherName = book.Publisher?.Name
    };
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