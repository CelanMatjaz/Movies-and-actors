using Microsoft.AspNetCore.Http;

using CommonData;
using System.Text;

public class RequestCountMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _service;

    public RequestCountMiddleware(RequestDelegate next, string service)
    {
        _next = next;
        _service = service;
    }

    public async Task InvokeAsync(HttpContext context, RequestEntryDbContext dbContext)
    {
        var newRequestEntry = new RequestCountEntry
        {
            Endpoint = context.Request.Path,
            Method = context.Request.Method,
            QueryParams = context.Request.QueryString.Value != null ? context.Request.QueryString.Value : "",
            Body = null,
            Timestamp = DateTime.Now.ToUniversalTime(),
            Service = _service
        };

        dbContext.Entries.Add(newRequestEntry);
        await dbContext.SaveChangesAsync();

        context.Response.Headers["request-id"] = newRequestEntry.Id.ToString();

        await _next(context);
    }

}