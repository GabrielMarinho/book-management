using BookManager.Application.Base;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Commands.Author;

public class CreateOrUpdateAuthorHandler(
    IAuthorRepository authorRepository) :
    BaseHandler<CreateOrUpdateAuthorResponse>,
    IRequestHandler<CreateOrUpdateAuthorRequest, CreateOrUpdateAuthorResponse>
{
    public async Task<CreateOrUpdateAuthorResponse> Handle(CreateOrUpdateAuthorRequest request, CancellationToken cancellationToken)
    {
        var author = new Domain.Entities.Author
        {
            IsActive = true,
            IsDeleted = false,
            Name = request.Name
        };

        await authorRepository.AddAsync(author, CancellationToken.None);
        await authorRepository.SaveChangesAsync(CancellationToken.None);
        
        return new CreateOrUpdateAuthorResponse();
    }
}