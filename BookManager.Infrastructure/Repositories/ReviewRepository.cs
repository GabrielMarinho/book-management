using BookManager.Domain.Entities;
using BookManager.Domain.Interfaces.Repositories;
using BookManager.Infrastructure.Context;

namespace BookManager.Infrastructure.Repositories;

public class ReviewRepository(BookManagerContext context) :
    BaseRepository<Review>(context),
    IReviewRepository
{
    
}