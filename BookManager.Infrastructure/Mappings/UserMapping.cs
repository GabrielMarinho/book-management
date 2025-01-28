using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infrastructure.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(a => a.Id).IsRequired().HasDefaultValueSql("NEXT VALUE FOR [SQ_User]");
    
        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(256);

        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.IsDeleted).HasDefaultValue(false);
        builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(u => u.UpdatedAt).IsRequired(false);

        builder.HasMany(u => u.Reviews);
    }
}