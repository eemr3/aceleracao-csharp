namespace ApiSql.Controller;
using ApiSql.DTO;
using ApiSql.Models;
using ApiSql.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
  private readonly IBookService _service;

  public BookController(IBookService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<IActionResult> AddBook([FromBody] BookDTO bookDto)
  {
    await _service.AddBookAsync(bookDto);

    // return CreatedAtAction(nameof(GetBookId), new { id = book.BookId }, book);
    return StatusCode(201, "Book created succefuly!");
  }

  [HttpGet("{bookId}")]
  public IActionResult GetBookId(int bookId)
  {
    try
    {
      var book = _service.GetBookIdAsync(bookId);

      return Ok(book);
    }
    catch (KeyNotFoundException err)
    {
      return NotFound(err.Message);
    }
  }

  [HttpGet]
  public IActionResult GetAllBooks()
  {
    var books = _service.GetBooks();

    return Ok(books);
  }
}