namespace BookManager.Application.Dtos;

public record ReviewDto
{
    public int Rate { get; init; }
    public string Description { get; init; }
}