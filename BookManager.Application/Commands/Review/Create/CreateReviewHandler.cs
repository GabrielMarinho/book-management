using BookManager.Application.Base;
using BookManager.Application.Enums;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Commands.Review.Create;

public class CreateReviewHandler(
    IBookRepository bookRepository,
    IUserRepository userRepository,
    IReviewRepository reviewRepository) :
    BaseHandler<CreateReviewResponse>,
    IRequestHandler<CreateReviewRequest, CreateReviewResponse>
{
    public async Task<CreateReviewResponse> Handle(CreateReviewRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository
            .FindAsync(w => 
                w.Identifier == request.BookIdentifier,
                cancellationToken);
        if (book is null)
        {
            AddError(ApplicationError.BookNotFound);
            return new CreateReviewResponse();
        }

        var user = await userRepository
            .FindAsync(w => 
                w.Identifier == request.UserIdentifier,
                cancellationToken);
        if (user is null)
        {
            AddError(ApplicationError.UserNotFound);
            return new CreateReviewResponse();
        }

        return new CreateReviewResponse()
        {

        };
    }
}