using FluentValidation;

namespace BookManager.Application.Queries.Book.Get;

public class GetBookValidator : AbstractValidator<GetBookRequest>
{
    public GetBookValidator()
    {
        RuleFor(x => x.Identifier)
            .Must(id => id != Guid.Empty)
            .WithMessage("Identifier must not be a default Guid");
    }
}