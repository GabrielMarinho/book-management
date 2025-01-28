using BookManager.Application.Base;
using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces.Repositories;
using MediatR;

namespace BookManager.Application.Commands.Book.CreateOrUpdate;

public class CreateOrUpdateBookHandler(IBookRepository bookRepository) :
    BaseHandler<CreateOrUpdateBookResponse>,
    IRequestHandler<CreateOrUpdateBookRequest, CreateOrUpdateBookResponse>
{
    public async Task<CreateOrUpdateBookResponse> Handle(CreateOrUpdateBookRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Book? book = null;

        if (request.Identifier.HasValue)
            book = await bookRepository
                .FindAsync(
                    f => f.Identifier == request.Identifier.Value,
                    cancellationToken);

        book ??= new Domain.Entities.Book();
        book.Title = request.Title;
        book.Description = request.Description;
        book.Isbn = request.Isbn;
        book.Publishing = request.Publishing;
        book.Genre = request.Genre;
        book.PublishedAt = request.PublishedAt;
        book.TotalPages = request.TotalPages;
        book.BookCover = request.BookCover;
        book.Authors = request.Authors.Select(s => new Domain.Entities.Author
        {
            Name = s.Name
        }).ToList();
        
        if (book.Id <= 0L)
        {
            await bookRepository.AddAsync(book, cancellationToken);
        }
        else
        {   
            await bookRepository.UpdateAsync(book);
        }

        await bookRepository.SaveChangesAsync(cancellationToken);
        
        return new CreateOrUpdateBookResponse
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
            Authors = book.Authors.Select(s => new AuthorDto
            {
                Name = s.Name
            })
        };
    }
}