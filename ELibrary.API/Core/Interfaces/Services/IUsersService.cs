namespace ELibrary.API.Core.Interfaces.Services;

public interface IUsersService
{
    Task Register(string name, string login, string password);

    Task<string> Login(string login, string password);
}