/*namespace Api2;

public class GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger, RequestDelegate next)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next.Invoke(httpContext);
        }
        catch (TaskCanceledException e)
        {
            logger.LogInformation("ErrorMessage {errorMessage}, stackTrace {stackTrace}",e.Message, e.StackTrace);
        }
    }
}*/