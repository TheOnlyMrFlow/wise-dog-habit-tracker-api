using System.Net;

namespace TWD.HabitTracker.Api.Middlewares.ErrorHandling;

public class DevelopmentGlobalErrorHandlingMiddleware : BaseGlobalErrorHandlingMiddleware
{
    public DevelopmentGlobalErrorHandlingMiddleware(RequestDelegate next) : base(next) { }

    protected override object GetHttpResponseBody(Exception e, string eventId)
    {
        return new
        {
            Type = "", 
            Title = "Internal Error",
            Status = HttpStatusCode.InternalServerError,
            Error = e,
            EventId = eventId
        };
    }
}