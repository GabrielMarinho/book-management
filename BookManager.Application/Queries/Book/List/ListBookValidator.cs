using FluentValidation;

namespace BookManager.Application.Queries.Book.List;

public class ListBookValidator : AbstractValidator<ListBookRequest>
{
    public ListBookValidator()
    {
        RuleFor(request => request.CurrentPage)
            .GreaterThan(0)
            .WithMessage("Current page must be greater than 0");

        RuleFor(request => request.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0");
    }
}