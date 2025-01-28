using MediatR;

namespace BookManager.Application.Commands.Book.Delete;

public class DeleteBookRequest : IRequest<DeleteBookResponse>
{
    public Guid Identifier { get; set; }
}