using FluentValidation;

namespace BookManager.Application.Commands.Book.CreateOrUpdate;

public class CreateOrUpdateBookValidator : AbstractValidator<CreateOrUpdateBookRequest>
{
    public CreateOrUpdateBookValidator()
    {
        When(x => x.Identifier.HasValue, () =>
        {
            RuleFor(x => x.Identifier.Value)
                .Must(id => id != Guid.Empty)
                .WithMessage("Identifier cannot be an empty GUID.");
        });
        
        RuleFor(book => book.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(book => book.Description)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(book => book.Isbn)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(book => book.Publishing)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(book => book.PublishedAt)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(book => book.TotalPages)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than zero.");

        RuleFor(book => book.Average)
            .InclusiveBetween(0, 5)
            .WithMessage("{PropertyName} must be between 0 and 5.");

        RuleFor(book => book.Authors)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}