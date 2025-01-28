using BookManager.Domain.Base;
using BookManager.Domain.Entities;
using BookManager.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Context;

public class BookManagerContext(DbContextOptions<BookManagerContext> options) : DbContext(options)
{
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Review> Review { get; set; }
    
    private static void RegisterIdenities(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence("SQ_Book")
            .HasMin(1)
            .StartsAt(1)
            .IncrementsBy(1);
         
        // modelBuilder.Entity<Book>()
        //     .Property(p => p.Id)
        //     .HasDefaultValueSql("NEXT VALUE FOR [SQ_Book]");
        
        modelBuilder.HasSequence("SQ_Author")
            .HasMin(1)
            .StartsAt(1)
            .IncrementsBy(1);
        
        // modelBuilder.Entity<Author>()
        //     .Property(p => p.Id)
        //     .HasDefaultValueSql("NEXT VALUE FOR [SQ_Author]");
        
        modelBuilder.HasSequence("SQ_User")
            .HasMin(1)
            .StartsAt(1)
            .IncrementsBy(1);
        
        // modelBuilder.Entity<User>()
        //     .Property(p => p.Id)
        //     .HasDefaultValueSql("NEXT VALUE FOR [SQ_User]");
        
        modelBuilder.HasSequence("SQ_Review")
            .HasMin(1)
            .StartsAt(1)
            .IncrementsBy(1);
        
        modelBuilder.Entity<Review>()
            .Property(p => p.Id)
            .HasDefaultValueSql("NEXT VALUE FOR [SQ_Review]");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>()
            .UseTpcMappingStrategy();
        
        RegisterIdenities(modelBuilder);

        modelBuilder.Entity<Author>(new AuthorMapping().Configure);
        modelBuilder.Entity<Book>(new BookMapping().Configure);
        modelBuilder.Entity<Review>(new ReviewMapping().Configure);
        modelBuilder.Entity<User>(new UserMapping().Configure);

        modelBuilder.Entity<Entity>()
            .Property(x => x.Identifier)
            .HasDefaultValueSql("NEWID()");
        
        modelBuilder.Entity<Entity>()
            .Property(x => x.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder
            .Entity<Entity>()
            .HasQueryFilter(f => f.IsActive && !f.IsDeleted);
        
        base.OnModelCreating(modelBuilder);
    }

    
}