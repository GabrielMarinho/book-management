using BookManager.Domain.Entities;
using BookManager.Domain.Interfaces.Repositories;
using BookManager.Infrastructure.Context;

namespace BookManager.Infrastructure.Repositories;

public class AuthorRepository(BookManagerContext context) : BaseRepository<Author>(context), IAuthorRepository
{
    
}