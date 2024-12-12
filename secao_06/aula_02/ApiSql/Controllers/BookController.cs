namespace ApiSql.Controller;
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
  public async Task<IActionResult> AddBook([FromBody] Book bookDto)
  {
    await _service.AddBookAsync(bookDto);

    // return CreatedAtAction(nameof(GetBookId), new { id = book.BookId }, book);
    return StatusCode(201, "Book created succefuly!");
  }

  [HttpGet("{bookId}")]
  public async Task<IActionResult> GetBookId(int bookId)
  {
    try
    {
      var book = await _service.GetBookIdAsync(bookId);

      return Ok(book);
    }
    catch (KeyNotFoundException err)
    {
      return NotFound(err.Message);
    }
  }

  [HttpGet]
  public async Task<IActionResult> GetAllBooks()
  {
    var books = await _service.GetBooks();

    return Ok(books);
  }
}