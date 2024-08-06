using ELibrary.API.Data;
using ELibrary.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.API.Repositories;

public class LessonRepository
{
    private readonly ELibraryDbContext _dbContext;
    
    public LessonRepository(ELibraryDbContext dbContext)
    { 
        _dbContext = dbContext;
    }

    public async Task AddLessonAsync1(Guid courseId, LessonEntity lesson)
    {
        var course = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId) ?? throw new Exception();
        
        course.Lessons.Add(lesson);

        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddLessonAsync2(Guid courseId, string title, string description, string lessonText)
    {
        var lesson = new LessonEntity
        {
            Title = title,
            Description = description,
            LessonText = lessonText,
            CourseId = courseId
        };

        await _dbContext.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();
    }
}