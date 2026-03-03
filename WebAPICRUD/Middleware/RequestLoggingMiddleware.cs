namespace WebAPICRUD.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
               _next=next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Console.WriteLine($"Incoming :{httpContext.Request.Method}  {httpContext.Request.Path}");
            await _next(httpContext); //pass to next middleware
            Console.WriteLine($"Outgoing: {httpContext.Response.StatusCode}");
        }
    }
}
