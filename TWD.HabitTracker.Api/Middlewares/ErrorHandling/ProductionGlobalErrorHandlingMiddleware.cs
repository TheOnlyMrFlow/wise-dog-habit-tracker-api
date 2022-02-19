using System.Net;

namespace TWD.HabitTracker.Api.Middlewares.ErrorHandling;

public class ProductionGlobalErrorHandlingMiddleware : BaseGlobalErrorHandlingMiddleware
{
    public ProductionGlobalErrorHandlingMiddleware(RequestDelegate next) : base(next) { }

    protected override object GetHttpResponseBody(Exception e, string eventId)
    {
        return new
        {
            Type = "", 
            Title = "Internal Error",
            Status = HttpStatusCode.InternalServerError,
            EventId = eventId
        };
    }
}