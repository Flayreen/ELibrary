using ELibrary.API.Shared;

namespace ELibrary.API.DAL.Entities;

public class UserEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Login { get; set; }
    
    public string PasswordHash { get; set; }
    
    public UserRole Role { get; set; }

    public List<UserEntity> FavouritesBooks = [];
}