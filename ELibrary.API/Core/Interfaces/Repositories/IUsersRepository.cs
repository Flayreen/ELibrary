using ELibrary.API.Core.Models;

namespace ELibrary.API.Core.Interfaces.Repositories;

public interface IUsersRepository
{
    Task AddUserAsync(User user);

    Task<User> GetUserByLoginAsync(string login);
}