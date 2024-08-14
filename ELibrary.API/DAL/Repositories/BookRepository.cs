using Microsoft.EntityFrameworkCore;
using ELibrary.API.Core.Interfaces;
using ELibrary.API.Core.Interfaces.Repositories;
using ELibrary.API.Core.Models;
using ELibrary.API.DAl;
using ELibrary.API.DAL.Entities;

namespace ELibrary.API.DAL.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ELibraryDbContext _dbContext;

    public BookRepository(ELibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BookEntity>> GetAllBooksAsync()
    {
        return await _dbContext.Books
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
    }

    public async Task<Guid> CreateBookAsync(Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id, 
            Title = book.Title, 
            Description = book.Description
        };
        
        await _dbContext.AddAsync(bookEntity);
        await _dbContext.SaveChangesAsync();
        
        return bookEntity.Id;
    }
}