using NubaHotel.BookingSystem.Api.Logging;

namespace NubaHotel.BookingSystem.Api.Middleware
{
    /// <summary>
    /// Middleware for handling global exception handling in the application.
    /// Captures unhandled exceptions during HTTP request processing and provides
    /// a centralized mechanism for logging and handling errors.
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        /// <summary>
        /// Represents the next middleware in the HTTP request processing pipeline.
        /// Used to invoke the next middleware component after the current middleware
        /// has finished processing or when delegating control of the request further
        /// down the pipeline.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Middleware for intercepting and handling unhandled exceptions in the HTTP request pipeline.
        /// Ensures centralized error handling, logging, and response generation for unexpected errors.
        /// </summary>
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Processes an incoming HTTP request, handles any unhandled exceptions that occur during the pipeline execution,
        /// and delegates the request to the next middleware in the pipeline.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> of the current HTTP request.</param>
        /// <param name="loggingService">The <see cref="LoggingService"/> instance used for logging exceptions.</param>
        /// <returns>A task that represents the asynchronous operation of processing the HTTP request.</returns>
        public async Task Invoke(HttpContext context, LoggingService loggingService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, loggingService);;
            }
        }

        /// <summary>
        /// Handles exceptions occurring during HTTP request processing, logs the exception,
        /// sets the appropriate HTTP status code, and generates an error response.
        /// This method centralizes exception handling and response formatting.
        /// </summary>
        /// <param name="context">The current HTTP context of the request being processed.</param>
        /// <param name="exception">The exception that was thrown during request processing.</param>
        /// <param name="loggingService">A service responsible for logging exceptions and errors.</param>
        /// <returns>A task that represents the asynchronous operation of handling the exception
        /// and writing the error response to the HTTP response.</returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception, LoggingService loggingService)
        {
            // Log the exception
            await loggingService.WriteLog(exception);

            // Set the appropriate status code based on an exception type
            context.Response.StatusCode = GetStatusCodeFromException(exception);
            context.Response.ContentType = "application/json";

            // Create a simple error response with just the message
            var errorResponse = new { error = exception.Message };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }

        /// <summary>
        /// Determines the appropriate HTTP status code based on the provided exception type.
        /// Maps specific exception types to status codes, enabling consistent error response handling.
        /// </summary>
        /// <param name="exception">
        /// The exception to evaluate for determining the corresponding HTTP status code.
        /// </param>
        /// <returns>
        /// The HTTP status code that corresponds to the specified exception type. Returns 500 (Internal Server Error)
        /// for unrecognized exceptions.
        /// </returns>
        private static int GetStatusCodeFromException(Exception exception) => exception switch
        {
            KeyNotFoundException => StatusCodes.Status404NotFound,
            ArgumentException => StatusCodes.Status400BadRequest,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}