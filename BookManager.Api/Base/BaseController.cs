using System.Text.Json;
using System.Text.Json.Serialization;
using BookManager.Application.Base;

namespace BookManager.Api.Base;

public abstract class BaseController
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    };

    private static IResult CreateResponse(object? response, int statusCodeSuccess)
    {
        if (response is null)
            Results.BadRequest("Was not possible to get the response");
        
        var commandResponse = response as CommandResponse;
        var statusCode = commandResponse?.Errors?.Count > 0 ?
            StatusCodes.Status400BadRequest :
            statusCodeSuccess;
        
        return Results.Text(JsonSerializer.Serialize(commandResponse, JsonSerializerOptions), 
            contentType: "application/json", 
            statusCode: statusCode);
    }

    protected static IResult Create200Response(object? response)
    {
        return CreateResponse(response, StatusCodes.Status200OK);
    }
    
    protected static IResult Create201Response(object? response)
    {
        return CreateResponse(response, StatusCodes.Status201Created);
    }
    
    
}