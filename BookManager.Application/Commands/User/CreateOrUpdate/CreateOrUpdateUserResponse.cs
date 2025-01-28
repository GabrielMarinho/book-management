using BookManager.Application.Base;

namespace BookManager.Application.Commands.User.CreateOrUpdate;

public class CreateOrUpdateUserResponse : CommandResponse
{
    public Guid Identifier { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}