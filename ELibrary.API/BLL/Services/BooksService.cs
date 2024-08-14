using ELibrary.API.Core.Interfaces;
using ELibrary.API.Core.Interfaces.Repositories;
using ELibrary.API.Core.Interfaces.Services;
using ELibrary.API.Core.Models;
using ELibrary.API.DAL.Entities;

namespace ELibrary.API.BLL.Services;

public class BooksService : IBookService
{
    private readonly IBookRepository _booksRepository;

    public BooksService(IBookRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<List<BookEntity>> GetAllBooksAsync()
    {
        return await _booksRepository.GetAllBooksAsync();
    }

    public async Task<Guid> CreateBookAsync(Book book)
    {
        return await _booksRepository.CreateBookAsync(book);
    }
}