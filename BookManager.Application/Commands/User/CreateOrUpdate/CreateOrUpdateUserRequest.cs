using MediatR;

namespace BookManager.Application.Commands.User.CreateOrUpdate;

public class CreateOrUpdateUserRequest : IRequest<CreateOrUpdateUserResponse>
{
    public Guid? Identifier { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}