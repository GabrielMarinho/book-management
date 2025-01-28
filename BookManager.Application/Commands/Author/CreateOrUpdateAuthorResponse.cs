using BookManager.Application.Base;

namespace BookManager.Application.Commands.Author;

public class CreateOrUpdateAuthorResponse : CommandResponse
{
    public Guid Identifier { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}