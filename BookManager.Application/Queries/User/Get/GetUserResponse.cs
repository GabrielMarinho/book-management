using BookManager.Application.Base;

namespace BookManager.Application.Queries.User.Get;

public class GetUserResponse : CommandResponse
{
    public Guid Identifier { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}