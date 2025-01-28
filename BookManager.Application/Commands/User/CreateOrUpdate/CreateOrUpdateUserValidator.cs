using FluentValidation;

namespace BookManager.Application.Commands.User.CreateOrUpdate;

public class CreateOrUpdateUserValidator : AbstractValidator<CreateOrUpdateUserRequest>
{
    public CreateOrUpdateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Email is not in a valid format.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        When(x => x.Identifier.HasValue, () =>
        {
            RuleFor(x => x.Identifier.Value)
                .Must(id => id != Guid.Empty)
                .WithMessage("Identifier cannot be an empty GUID.");
        });
    }
}