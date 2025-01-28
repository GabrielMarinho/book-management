using MediatR;

namespace BookManager.Application.Commands.User.Delete;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public Guid Identifier { get; set; }
}