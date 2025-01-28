using BookManager.Domain.Entities;
using BookManager.Domain.Interfaces.Repositories;
using BookManager.Infrastructure.Context;

namespace BookManager.Infrastructure.Repositories;

public class BookRepository(BookManagerContext context) :
    BaseRepository<Book>(context), IBookRepository
{
    
}