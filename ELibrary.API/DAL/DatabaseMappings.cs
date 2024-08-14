using AutoMapper;
using ELibrary.API.Core.Models;
using ELibrary.API.DAL.Entities;

namespace ELibrary.API.DAl;

public class DatabaseMappings : Profile
{
    public DatabaseMappings()
    {
        CreateMap<UserEntity, User>();
        
        CreateMap<User, UserEntity>();
    }
}