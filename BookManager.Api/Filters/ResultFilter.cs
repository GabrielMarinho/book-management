using Microsoft.AspNetCore.Mvc.Filters;

namespace BookManager.Api.Filters;

public class ResultFilter : IResult
{
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        var ctx = httpContext.Response.StatusCode;
        if (ctx > 200)
        {
            await httpContext.Response.WriteAsync("Error occurred");
        }
    }
}