using BookManager.Application.Base;
using BookManager.Application.Dtos;
using BookManager.Domain.Enums;

namespace BookManager.Application.Commands.Book.CreateOrUpdate;

public class CreateOrUpdateBookResponse : CommandResponse
{
    public Guid Identifier { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }

    public string Publishing { get; set; }
    public BookGenre Genre { get; set; }
    public DateTime PublishedAt { get; set; }
    public int TotalPages { get; set; }
    public decimal Average { get; set; }
    public string BookCover { get; set; }

    public IEnumerable<AuthorDto> Authors { get; set; }
}