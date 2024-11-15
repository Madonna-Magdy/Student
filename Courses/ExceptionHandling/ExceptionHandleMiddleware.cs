using Business.ExceptionHandling;
using System.Net;

namespace Students.ExceptionHandling
{

    public class ExceptionHandleMiddleware
    {
        private readonly ILogger<ExceptionHandleMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<ExceptionHandleMiddleware>() ??
                      throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is PortalValidationException)
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                else if (ex is AuthorizationException)
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                else if (ex is ForbiddenException)
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                else
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
