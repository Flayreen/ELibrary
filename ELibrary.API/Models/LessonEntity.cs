namespace ELibrary.API.Models;

public class LessonEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string LessonText { get; set; } = string.Empty;
    
    public CourseEntity? Course { get; set; }
}