namespace ThisDoesNotExist;

public class RequestTrackingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTrackingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task InvokeAsync(HttpContext context, IRequestTracker requestTracker)
    {
        requestTracker.Add(context);

        // Call the next delegate/middleware
        return _next(context);
    }
}

