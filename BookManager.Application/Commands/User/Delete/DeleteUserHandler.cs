using BookManager.Application.Base;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Commands.User.Delete;

public class DeleteUserHandler(IUserRepository userRepository) :
    BaseHandler<DeleteUserResponse>,
    IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        await userRepository.DeleteAsync(w => 
                w.Identifier == request.Identifier,
            cancellationToken);

        return new DeleteUserResponse();
    }
}