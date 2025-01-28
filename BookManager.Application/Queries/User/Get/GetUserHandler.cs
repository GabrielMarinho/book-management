using BookManager.Application.Base;
using BookManager.Application.Enums;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Queries.User.Get;

public class GetUserHandler(IUserRepository userRepository) :
    BaseHandler<GetUserResponse>,
    IRequestHandler<GetUserRequest, GetUserResponse>
{
    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .FindAsync(w => 
                w.Identifier == request.Identifier,
                cancellationToken);
        
        if (user is not null)
            return new GetUserResponse
            {
                Identifier = user.Identifier,
                Email = user.Email,
                Name = user.Name
            };

        AddError(ApplicationError.UserNotFound);
        return new GetUserResponse();
    }
}