using FluentValidation;

namespace BookManager.Application.Queries.User.Get;

public class GetUserValidator : AbstractValidator<GetUserRequest>
{
    public GetUserValidator()
    {
        RuleFor(x => x.Identifier)
            .Must(id => id != Guid.Empty)
            .WithMessage("Identifier must not be a default Guid");
    }
}