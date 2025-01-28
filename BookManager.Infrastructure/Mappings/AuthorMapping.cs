using System.ComponentModel.DataAnnotations.Schema;
using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infrastructure.Mappings;

public class AuthorMapping
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        // builder.ToTable(nameof(Author), tb => tb.Property(e => e.Id).UseIdentityColumn(1, 1));

        builder.Property(a => a.Id).IsRequired().HasDefaultValueSql("NEXT VALUE FOR [SQ_Author]");
        
        builder.Property(a => a.Name).IsRequired().HasMaxLength(200);
        builder.Property(a => a.BookId).IsRequired();
        

        builder.Property(a => a.IsActive).HasDefaultValue(true);
        builder.Property(a => a.IsDeleted).HasDefaultValue(false);
        builder.Property(a => a.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(a => a.UpdatedAt).IsRequired(false);
        
        builder.HasOne(a => a.Book).WithMany(b => b.Authors)
            .HasForeignKey(a => a.BookId);
    }
}