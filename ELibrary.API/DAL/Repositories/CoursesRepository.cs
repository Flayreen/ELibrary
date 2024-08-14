// using ELibrary.API.Core.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using ELibrary.API.Data.Entities;
//
// namespace ELibrary.API.Data.Repositories;
//
// public class CoursesRepository : ICoursesRepository
// {
//     private readonly ELibraryDbContext _dbContext;
//     
//     public CoursesRepository(ELibraryDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//
//     public async Task<List<CourseEntity>> GetAllCoursesAsync()
//     {
//         return await _dbContext.Courses
//             .AsNoTracking()
//             .OrderBy(c => c.Title)
//             .ToListAsync();
//     }
//     
//     public async Task<CourseEntity?> GetCourseByIdAsync(Guid id)
//     {
//         return await _dbContext.Courses
//             .AsNoTracking()
//             .FirstOrDefaultAsync(c => c.Id == id);
//     }
//
//     public async Task<List<CourseEntity>> GetCoursesByFilter(string title, decimal price)
//     {
//         var query = _dbContext.Courses.AsNoTracking();
//
//         if (!string.IsNullOrEmpty(title))
//         {
//             query = query.Where(c => c.Title.Contains(title));
//         }
//
//         if (price > 0)
//         {
//             query = query.Where(c => c.Price > price);
//         }
//
//         return await query.ToListAsync();
//     }
//     
//     public async Task<List<CourseEntity>> GetCoursesByPage(int page, int pageSize)
//     {
//         return await _dbContext.Courses
//             .AsNoTracking()
//             .Skip((page - 1) * pageSize)
//             .Take(pageSize)
//             .ToListAsync();
//     }
//
     // public async Task AddCourseAsync(Guid id, Guid authorId, string title, string description, decimal price)
     // {
     //     var courseEntity = new CourseEntity
     //     {
     //         Id = id,
     //         AuthorId = authorId,
     //         Title = title,
     //         Description = description,
     //         Price = price
     //     };
     //
     //     await _dbContext.AddAsync(courseEntity);
     //     await _dbContext.SaveChangesAsync();
     // }
//     
//     public async Task UpdateCourseAsync(Guid id, string title, string description, decimal price)
//     {
//         await _dbContext.Courses
//             .AsNoTracking()
//             .Where(c => c.Id == id)
//             .ExecuteUpdateAsync(s => s
//                 .SetProperty(c => c.Title, title)
//                 .SetProperty(c => c.Description, description)
//                 .SetProperty(c => c.Price, price));
//     }
//     
//     public async Task DeleteCourseAsync(Guid id)
//     {
//         await _dbContext.Courses
//             .AsNoTracking()
//             .Where(c => c.Id == id)
//             .ExecuteDeleteAsync();
//     }
// }