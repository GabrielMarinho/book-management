using FluentValidation;

namespace BookManager.Application.Commands.Book.Delete;

public class DeleteBookValidator : AbstractValidator<DeleteBookRequest>
{
    public DeleteBookValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEqual(Guid.Empty);
    }
}