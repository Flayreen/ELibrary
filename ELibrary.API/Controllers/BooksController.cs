using ELibrary.API.Contracts.Books;
using ELibrary.API.Core.Interfaces;
using ELibrary.API.Core.Interfaces.Services;
using ELibrary.API.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _booksService;
    
    public BooksController(IBookService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookResponse>>> GetCourses()
    {
        var books = await _booksService.GetAllBooksAsync();

        var response = books.Select(c => new BookResponse(c.Id, c.Title, c.Description));

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook([FromBody] BookRequest request)
    {
        var (book, error) = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description
        );

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var bookId = await _booksService.CreateBookAsync(book);

        return bookId;
    }
}