using FluentValidation;

namespace BookManager.Application.Commands.Review.Create;

public class CreateReviewValidator : AbstractValidator<CreateReviewRequest>
{

    public CreateReviewValidator()
    {
        RuleFor(x => x.BookIdentifier)
            .NotEqual(Guid.Empty)
            .WithMessage("Book Identifier is required");
        
        RuleFor(x => x.UserIdentifier)
            .NotEmpty()
            .WithMessage("User Identifier is required");
        
        RuleFor(x => x.Rate)
            .InclusiveBetween(1, 5)
            .WithMessage("Rate should be between 1 and 5");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required");
    }
    
}