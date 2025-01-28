using MediatR;

namespace BookManager.Application.Queries.Book.Get;

public class GetBookRequest : IRequest<GetBookResponse>
{
    public Guid Identifier { get; set; }
}