using ELibrary.API.Core.Models;
using ELibrary.API.DAL.Entities;

namespace ELibrary.API.Core.Interfaces.Repositories;

public interface IBookRepository
{
    Task<List<BookEntity>> GetAllBooksAsync();
    
    Task<Guid> CreateBookAsync(Book book);
}