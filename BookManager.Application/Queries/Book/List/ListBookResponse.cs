using BookManager.Application.Base;
using BookManager.Application.Dtos;

namespace BookManager.Application.Queries.Book.List;

public class ListBookResponse : BasePagingResponse<BookDto>
{
}