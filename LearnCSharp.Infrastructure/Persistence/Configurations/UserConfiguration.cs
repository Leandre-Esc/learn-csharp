using LearnCSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnCSharp.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        
        
        builder.HasIndex(x => x.Username).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}