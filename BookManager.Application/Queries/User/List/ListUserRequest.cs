using MediatR;

namespace BookManager.Application.Queries.User.List;

public class ListUserRequest : IRequest<ListUserResponse>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}