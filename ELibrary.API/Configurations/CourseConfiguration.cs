using ELibrary.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibrary.API.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(c => c.Lessons)
            .WithOne(l => l.Course);

        builder
            .HasOne(c => c.Author)
            .WithOne(a => a.Course);

        builder
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);
    }
}