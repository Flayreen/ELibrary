namespace ELibrary.API.Contracts.Books;

public record BookRequest (
    string Title, 
    string Description);