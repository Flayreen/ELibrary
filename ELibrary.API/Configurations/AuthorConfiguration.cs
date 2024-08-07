using ELibrary.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibrary.API.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .HasOne(a => a.Course)
            .WithOne(c => c.Author)
            .HasForeignKey<CourseEntity>(c => c.AuthorId);
    }
}