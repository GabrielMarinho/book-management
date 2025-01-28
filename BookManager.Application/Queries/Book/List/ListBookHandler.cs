using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Queries.Book.List;

public class ListBookHandler(IBookRepository bookRepository) :
    IRequestHandler<ListBookRequest, ListBookResponse>
{
    public async Task<ListBookResponse> Handle(ListBookRequest request, CancellationToken cancellationToken)
    {
        var items = new List<BookDto>();
        var totalItems = await bookRepository.CountAsync(cancellationToken);
        
        await foreach (var book in bookRepository
                           .PageAsync(request.CurrentPage,
                               request.PageSize)
                           .WithCancellation(cancellationToken))
        {
            items.Add(new BookDto()
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
                BookCover = book.BookCover
            });
        }
        
        return new ListBookResponse
        {
            CurrentPage = request.CurrentPage,
            PageSize = request.PageSize,
            TotalItems = totalItems,
            Items = items
        };
    }
}