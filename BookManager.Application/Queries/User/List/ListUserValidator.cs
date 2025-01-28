using FluentValidation;

namespace BookManager.Application.Queries.User.List;

public class ListUserValidator : AbstractValidator<ListUserRequest>
{
    public ListUserValidator()
    {
        RuleFor(request => request.CurrentPage)
            .GreaterThan(0)
            .WithMessage("Current page must be greater than 0");

        RuleFor(request => request.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0");
    }
}