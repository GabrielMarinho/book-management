using MediatR;

namespace BookManager.Application.Commands.Author;

public class CreateOrUpdateAuthorRequest : IRequest<CreateOrUpdateAuthorResponse>
{
    public string Name { get; set; }
}