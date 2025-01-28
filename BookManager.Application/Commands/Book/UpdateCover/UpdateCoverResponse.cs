using BookManager.Application.Base;

namespace BookManager.Application.Commands.Book.UpdateCover;

public class UpdateCoverResponse : CommandResponse
{
    public Guid Identifier { get; set; }
    public string Cover { get; set; }
}