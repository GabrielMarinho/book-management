using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infrastructure.Mappings;

public class BookMapping
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {   
        // builder.ToTable(nameof(Book), tb => tb.Property(e => e.Id).UseIdentityColumn(1, 1));
        
        builder.Property(a => a.Id).IsRequired().HasDefaultValueSql("NEXT VALUE FOR [SQ_Book]");
        
        builder.Property(book => book.Title).IsRequired().HasMaxLength(200);
        builder.Property(book => book.Description).IsRequired().HasMaxLength(2000);
        builder.Property(book => book.Isbn).IsRequired().HasMaxLength(13);
        builder.Property(book => book.Publishing).IsRequired().HasMaxLength(200);
        builder.Property(book => book.Genre).IsRequired();
        builder.Property(book => book.PublishedAt).IsRequired();
        builder.Property(book => book.TotalPages).IsRequired();
        builder.Property(book => book.Average).IsRequired();
        builder.Property(book => book.BookCover).IsRequired().HasMaxLength(-1);

        builder.Property(book => book.IsActive).HasDefaultValue(true);
        builder.Property(book => book.IsDeleted).HasDefaultValue(false);
        builder.Property(book => book.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(book => book.UpdatedAt).IsRequired(false);

        builder.HasMany(book => book.Authors)
            .WithOne(author => author.Book)
            .HasForeignKey(author => author.BookId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(book => book.Reviews)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);
    }
}