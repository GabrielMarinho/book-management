using BookManager.Application.Base;
using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Queries.Book.Get;

public class GetBookHandler(IBookRepository bookRepository) :
    BaseHandler<GetBookResponse>,
    IRequestHandler<GetBookRequest, GetBookResponse>
{
    public async Task<GetBookResponse> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository
            .FindAsync(w => w.Identifier == request.Identifier,
                cancellationToken, 
                p => p.Authors);
        if (book is null)
            return new GetBookResponse();
        
        return new GetBookResponse
        {
            Item = new BookDto()
            {
                Identifier = book.Identifier,
                Title = book.Title,
                Description = book.Description,
                Isbn = book.Isbn,
                Publishing = book.Publishing,
                Genre = book.Genre,
                PublishedAt = book.PublishedAt,
                TotalPages = book.TotalPages,
                Average = book.Average,
                BookCover = book.BookCover,
                Authors = book.Authors?.Select(s => new AuthorDto
                {
                    Name = s.Name
                })
            }
        };
    }
}