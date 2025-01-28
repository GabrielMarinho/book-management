using BookManager.Domain.Interfaces.Repositories;
using BookManager.Infrastructure.Context;
using BookManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Infrastructure.IoC;

public static class InfraStructureDependency
{
    public static void RegisterInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddDbContext<BookManagerContext>(options =>
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
            options.UseSqlServer(connectionString);
        });
    }
}