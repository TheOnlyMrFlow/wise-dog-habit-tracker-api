using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace TWD.HabitTracker.Api.Middlewares.ErrorHandling;

public abstract class BaseGlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public BaseGlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<BaseGlobalErrorHandlingMiddleware> logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var eventId = Activity.Current?.Id ?? context.TraceIdentifier;
            
            logger.LogError(eventId, ex);
            
            var body = JsonConvert.SerializeObject(GetHttpResponseBody(ex, eventId));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            await context.Response.WriteAsync(body);
        }
    }

    protected abstract object GetHttpResponseBody(Exception e, string eventId);
}