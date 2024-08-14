using ELibrary.API.Core.Models;
using ELibrary.API.DAL.Entities;

namespace ELibrary.API.Core.Interfaces.Services;

public interface IBookService
{
    Task<List<BookEntity>> GetAllBooksAsync();

    Task<Guid> CreateBookAsync(Book book);
}