using ELibrary.API.Core.Models;

namespace ELibrary.API.Core.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
}