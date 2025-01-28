using BookManager.Domain.Entities;
using BookManager.Domain.Interfaces.Repositories;
using BookManager.Infrastructure.Context;

namespace BookManager.Infrastructure.Repositories;

public class UserRepository(BookManagerContext context) : BaseRepository<User>(context), IUserRepository
{
}