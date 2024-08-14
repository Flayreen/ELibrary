using ELibrary.API.Shared;

namespace ELibrary.API.Core.Models;

public class User
{
    private User(Guid id, string name, string login, string passwordHash)
    {
        Id = id;
        Name = name;
        Login = login;
        PasswordHash = passwordHash;
    }
    
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }

    public string Login { get; private set; }
    
    public string PasswordHash { get; private set; }

    public static User Create(Guid id, string name, string login, string passwordHash)
    {
        return new User(id, name, login, passwordHash);
    }
}