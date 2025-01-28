using BookManager.Application.Base;
using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Queries.User.List;

public class ListUserHandler(IUserRepository userRepository) :
    BaseHandler<ListUserResponse>,
    IRequestHandler<ListUserRequest, ListUserResponse>
{
    public async Task<ListUserResponse> Handle(ListUserRequest request, CancellationToken cancellationToken)
    {
        var items = new List<UserDto>();
        var totalItems = await userRepository
            .CountAsync(cancellationToken);
        
        await foreach (var user in userRepository
                           .PageAsync(request.CurrentPage,
                               request.PageSize)
                           .WithCancellation(cancellationToken))
        {
            items.Add(new UserDto()
            {
                Identifier = user.Identifier,
                Name = user.Name,
                Email = user.Email
            });
        }
        
        return new ListUserResponse()
        {
            CurrentPage = request.CurrentPage,
            PageSize = request.PageSize,
            TotalItems = totalItems,
            Items = items
        };
    }
}