using System.Text.Json;
using System.Text.Json.Serialization;
using BookManager.Api.Base;
using BookManager.Api.Filters;
using BookManager.Application.Commands.Book.CreateOrUpdate;
using BookManager.Application.Commands.Book.Delete;
using BookManager.Application.Commands.Book.UpdateCover;
using BookManager.Application.Queries.Book.Get;
using BookManager.Application.Queries.Book.List;
using MediatR;

namespace BookManager.Api.Extensions;

public class BookEndpointsExtension : BaseController
{
    public static void RegisterBookEndpoints(WebApplication app)
    {
        var group = app.MapGroup("/book");
        
        group.MapPost("", async (CreateOrUpdateBookRequest request, IMediator mediator) => 
                await mediator.Send(request))
            .AddEndpointFilter<EndpointFilter<CreateOrUpdateBookRequest>>();

        group.MapGet("/List", async ([AsParameters] ListBookRequest request, IMediator mediator) =>
                await mediator.Send(request))
            .AddEndpointFilter<EndpointFilter<ListBookRequest>>();
        
        group.MapGet("", async ([AsParameters] GetBookRequest request, IMediator mediator) =>
                await mediator.Send(request))
            .AddEndpointFilter<EndpointFilter<GetBookRequest>>();

        group.MapPost("/Cover",
            async ([AsParameters] UpdateCoverRequest request, IMediator mediator) =>
                Create200Response(await mediator.Send(request)))
            .DisableAntiforgery()
            .AddEndpointFilter<EndpointFilter<UpdateCoverRequest>>();
        
        group.MapDelete("", async ([AsParameters] DeleteBookRequest request, IMediator mediator) =>
                await mediator.Send(request))
            .AddEndpointFilter<EndpointFilter<DeleteBookRequest>>();
    }
}