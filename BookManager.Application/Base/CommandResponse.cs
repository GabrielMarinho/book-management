using FluentValidation.Results;

namespace BookManager.Application.Base;

public abstract class CommandResponse
{   
    public bool Success => Errors?.Count == 0;
    public DateTime Executed { get; init; } = DateTime.UtcNow;
    public List<ValidationFailure> Errors { get; init; } = [];
}