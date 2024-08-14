namespace ELibrary.API.Core.Models;

public class Book
{
    private const int MAX_TITLE_LENGTH = 250;
    
    private Book(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    
    public Guid Id { get; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public static (Book Book, string Error) Create(Guid id, string title, string description)
    {
        string error = string.Empty;

        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            error = $"Title can't be empty or longer than {MAX_TITLE_LENGTH} letters";
        }

        var book = new Book(id, title, description);

        return (book, error);
    }
}