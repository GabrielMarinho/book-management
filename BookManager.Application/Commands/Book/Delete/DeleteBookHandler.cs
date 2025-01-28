using BookManager.Application.Base;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Commands.Book.Delete;

public class DeleteBookHandler(IBookRepository bookRepository) :
    BaseHandler<DeleteBookResponse>,
    IRequestHandler<DeleteBookRequest, DeleteBookResponse>
{
    public async Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        await bookRepository.DeleteAsync(w => 
                w.Identifier == request.Identifier,
            cancellationToken);

        return new DeleteBookResponse();
    }
}