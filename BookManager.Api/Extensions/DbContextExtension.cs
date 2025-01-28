using BookManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Api.Extensions;

public static class DbContextExtension
{
    public static async Task ExecuteMigrationAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BookManagerContext>();

        try
        {
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}