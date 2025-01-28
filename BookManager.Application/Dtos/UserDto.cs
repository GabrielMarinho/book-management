namespace BookManager.Application.Dtos;

public record UserDto
{
    public Guid Identifier { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
}