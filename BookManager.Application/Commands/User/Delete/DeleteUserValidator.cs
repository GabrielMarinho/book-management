using FluentValidation;

namespace BookManager.Application.Commands.User.Delete;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.Identifier)
            .Must(id => id != Guid.Empty)
            .WithMessage("Identifier must not be a default Guid");
    }
}