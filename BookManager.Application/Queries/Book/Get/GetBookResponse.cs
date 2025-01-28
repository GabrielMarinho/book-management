using BookManager.Application.Base;
using BookManager.Application.Dtos;

namespace BookManager.Application.Queries.Book.Get;

public class GetBookResponse : CommandResponse
{
    public BookDto Item { get; set; }
}