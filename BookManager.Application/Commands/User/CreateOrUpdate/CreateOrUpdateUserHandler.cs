using BookManager.Application.Base;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Commands.User.CreateOrUpdate;

public class CreateOrUpdateUserHandler(IUserRepository userRepository) : 
    BaseHandler<CreateOrUpdateUserResponse>,
    IRequestHandler<CreateOrUpdateUserRequest, CreateOrUpdateUserResponse>
{
    public async Task<CreateOrUpdateUserResponse> Handle(CreateOrUpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .FindAsync(w => w.Identifier == request.Identifier,
                cancellationToken) ?? new Domain.Entities.User();

        user.Name = request.Name;
        user.Email = request.Email;

        if (request.Identifier is null)
        {
            await userRepository
                .AddAsync(user, cancellationToken);
        }

        await userRepository.SaveChangesAsync(cancellationToken);

        return new CreateOrUpdateUserResponse
        {
            Identifier = user.Identifier,
            Email = request.Email,
            Name = request.Name
        };
    }
}