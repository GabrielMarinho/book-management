using FluentValidation;

namespace BookManager.Application.Commands.Book.UpdateCover;

public class UpdateCoverValidator : AbstractValidator<UpdateCoverRequest>
{
    public UpdateCoverValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage("Identifier must not be empty");
        
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File must not be null");
        
        RuleFor(x => x.File.FileName)
            .NotEmpty()
            .WithMessage("File name must not be empty");
        
        RuleFor(x => x.File.FileName)
            .Must(fn => fn.EndsWith(".jpg") || fn.EndsWith(".png"))
            .WithMessage("File must be a .jpg or .png file");
        
        RuleFor(x => x.File.Length)
            .GreaterThan(0)
            .WithMessage("File size must greater than 0");
    }
    
}