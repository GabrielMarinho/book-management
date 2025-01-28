using BookManager.Application.Dtos;
using BookManager.Domain.Dtos;
using FluentValidation.Results;

namespace BookManager.Api.Extensions;

public static class FluentValidationExtension
{
    public static IReadOnlyCollection<Error> GetValidationErrors(this IReadOnlyCollection<ValidationFailure> errors)
    {
        return errors?
            .Select(x => 
                new Error(x.ErrorCode, x.ErrorMessage))
            .ToList() ?? 
               new List<Error>()
                   .AsReadOnly()
                   .ToList();
    }

}