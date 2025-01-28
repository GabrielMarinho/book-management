using BookManager.Application.Enums;
using BookManager.Application.Extensions;
using FluentValidation.Results;

namespace BookManager.Application.Base;

public abstract class BaseHandler<TResponse> where TResponse: CommandResponse
{
    private readonly List<ValidationFailure> _errors;

    protected BaseHandler()
    {
        _errors = new List<ValidationFailure>(100);
    }
    
    protected virtual void AddError(ApplicationError error)
    {
        _errors.Add(
            new ValidationFailure(
                error.GetDisplayName(),
                error.GetDescription()));
    }

    protected TResponse TerminateWithErrors()
    {
        var response = Activator.CreateInstance<TResponse>();
        response.Errors.AddRange(_errors);
        return response;
    }

    protected TResponse AddErrorAndTerminate(ApplicationError error)
    {
        AddError(error);
        return TerminateWithErrors();
    }
}