using MediatR;

namespace BookManager.Application.Queries.Book.List;

public class ListBookRequest : IRequest<ListBookResponse>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}