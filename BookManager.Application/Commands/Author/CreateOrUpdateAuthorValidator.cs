using FluentValidation;

namespace BookManager.Application.Commands.Author;

public class CreateOrUpdateAuthorValidator : AbstractValidator<CreateOrUpdateAuthorRequest>
{
    public CreateOrUpdateAuthorValidator()
    {
        RuleFor(x => x.Name)
            .NotNull();
    }
}