using System.Linq.Expressions;
using AutoMapper;
using ELibrary.API.Core.Interfaces;
using ELibrary.API.Core.Interfaces.Repositories;
using ELibrary.API.Core.Models;
using ELibrary.API.DAl;
using ELibrary.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.API.DAL.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ELibraryDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public UsersRepository(ELibraryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task AddUserAsync(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            Name = user.Name,
            Login = user.Login,
            PasswordHash = user.PasswordHash,
        };

        await _dbContext.Users.AddAsync(userEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByLoginAsync(string login)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == login) ?? throw new Exception();

        return _mapper.Map<User>(userEntity);
    }
}