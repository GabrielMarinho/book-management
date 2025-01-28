using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infrastructure.Mappings;

public class ReviewMapping : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(a => a.Id).IsRequired().HasDefaultValueSql("NEXT VALUE FOR [SQ_Review]");
        
        builder.Property(review => review.Rate).IsRequired();
        builder.Property(review => review.Description).IsRequired().HasMaxLength(2000);

        builder.HasOne(review => review.User)
            .WithMany()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}