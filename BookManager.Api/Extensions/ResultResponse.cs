using BookManager.Application.Base;
using BookManager.Domain.Dtos;

namespace BookManager.Api.Extensions;

public static class ResultResponse
{

    public static IResult ToResponse(this CommandResponse commandResponse)
    {
        if (commandResponse.Success)
            return Results.Ok(commandResponse);
        
        var errors = commandResponse.
            Errors.
            Select(e => new Error(
                e.ErrorCode, e.ErrorMessage
                ))
            .ToArray();
        return Results.BadRequest(new {
            Success = false,
            Errors = errors
        });
    }
}