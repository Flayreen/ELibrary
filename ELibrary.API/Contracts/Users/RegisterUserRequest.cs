namespace ELibrary.API.Contracts.Users;

public record RegisterUserRequest(string Name, string Login, string Password);