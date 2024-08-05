using ELibrary.API.Configurations;
using ELibrary.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.API.Data;

public class ELibraryDbContext : DbContext 
{
    private readonly IConfiguration _configuration;

    public ELibraryDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
    }
}