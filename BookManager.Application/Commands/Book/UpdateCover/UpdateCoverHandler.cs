using BookManager.Application.Base;
using BookManager.Application.Enums;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Commands.Book.UpdateCover;

public class UpdateCoverHandler(IBookRepository bookRepository) :
    BaseHandler<UpdateCoverResponse>,
    IRequestHandler<UpdateCoverRequest, UpdateCoverResponse>
{
    public async Task<UpdateCoverResponse> Handle(UpdateCoverRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository
            .FindAsync(w => w.Identifier == request.Identifier,
                cancellationToken);
        if (book is null)
            return AddErrorAndTerminate(ApplicationError.BookNotFound);

        using var memoryStream = new MemoryStream();
        await request.File.CopyToAsync(memoryStream, CancellationToken.None);
        memoryStream.Position = 0L;
        
        // Upload the file if less than 2 MB
        if (memoryStream.Length > 2097152)
        {
            AddError(ApplicationError.BookCoverFileOverSize);
            return new UpdateCoverResponse();
        }

        var coverInBytes = memoryStream.ToArray();
        book.BookCover = Convert.ToBase64String(coverInBytes);

        await bookRepository.SaveChangesAsync(cancellationToken);

        return new UpdateCoverResponse
        {
            Identifier = request.Identifier,
            Cover = book.BookCover
        };
    }
}