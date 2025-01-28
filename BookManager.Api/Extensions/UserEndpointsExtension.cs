using BookManager.Application.Commands.User.CreateOrUpdate;
using BookManager.Application.Commands.User.Delete;
using MediatR;

namespace BookManager.Api.Extensions;

public static class UserEndpointsExtension
{
    public static void RegisterUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/user");
        
        group.MapPost("", async (CreateOrUpdateUserRequest request, IMediator mediator) => 
            await mediator.Send(request));
        
        group.MapDelete("/{identifier:guid}", async (Guid identifier, IMediator mediator) =>
            await mediator.Send(new DeleteUserRequest
            {
                Identifier = identifier
            }));
    }
}