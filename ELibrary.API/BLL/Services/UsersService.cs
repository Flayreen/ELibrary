using ELibrary.API.Core.Interfaces.Auth;
using ELibrary.API.Core.Interfaces.Repositories;
using ELibrary.API.Core.Interfaces.Services;
using ELibrary.API.Core.Models;

namespace ELibrary.API.BLL.Services;

public class UsersService : IUsersService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUsersRepository _usersRepository;
    private readonly IJwtProvider _jwtProvider;

    public UsersService(
        IUsersRepository usersRepository, 
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _passwordHasher = passwordHasher;
        _usersRepository = usersRepository;
        _jwtProvider = jwtProvider;
    }
    
    public async Task Register(string name, string login, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var user =  User.Create(Guid.NewGuid(), name, login, hashedPassword);

        await _usersRepository.AddUserAsync(user); 
    }

    public async Task<string> Login(string login, string password)
    {
        var user = await _usersRepository.GetUserByLoginAsync(login);

        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (!result)
        {
            throw new Exception("Failed login");
        }

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }
}