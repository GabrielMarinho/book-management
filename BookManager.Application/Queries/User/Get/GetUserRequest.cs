using MediatR;

namespace BookManager.Application.Queries.User.Get;

public class GetUserRequest : IRequest<GetUserResponse>
{
    public Guid Identifier { get; set; }
}