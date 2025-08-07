using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace Vehicle_Rental_System_Web.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
        }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
    }
}

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/html";

            var errorHtml = $@"
                <html>
                <head>
                    <title>Error</title>
                    <script>
                        alert('An unexpected error occurred. Please try again.');
                        window.history.back();
                    </script>
                </head>
                <body>
                    <h2>Something went wrong</h2>
                    <p>An unexpected error occurred. Please try again.</p>
                    <a href='/'>Go to Home</a>
                </body>
                </html>";

            await context.Response.WriteAsync(errorHtml);
        }
    }
}