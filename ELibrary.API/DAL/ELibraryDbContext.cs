using ELibrary.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.API.DAl;

public class ELibraryDbContext : DbContext 
{
    private readonly IConfiguration _configuration;

    public ELibraryDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
}