using BookManager.Api.Extensions;
using BookManager.Application.Base;
using BookManager.Application.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Filters;

public class EndpointFilter<T> : IEndpointFilter where T: class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var entity = context.Arguments
            .OfType<T>()
            .FirstOrDefault(a => a?.GetType() == typeof(T));

        if (entity is null)
        {
            return Results.Problem("Error Not Found");
        }

        var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<T>>();
        var result = await validator.ValidateAsync(entity);

        if (!result.IsValid)
            return new BadRequestObjectResult(
                result
                    .Errors
                    .GetValidationErrors());
        
        // var response = await next(context);
        // if (response is null)
        //     return Results.BadRequest();

        // var commandResponse = response as CommandResponse;    
        // if (commandResponse is null)
        //     return new BadRequestObjectResult(Results.Json(commandResponse));

        return await next(context);
    }
}