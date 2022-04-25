using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApi.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private const string APIKEYNAME = "ApiKey";

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized client.");
                    return;
                }

                var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

                var apiKey = appSettings.GetValue<string>(APIKEYNAME);

                if (!apiKey.Equals(extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized client.");
                    return;
                }

                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            var response = new
            {
                Title = GetTitle(exception),
                Status = statusCode,
                Detail = exception.Message,
                Errors = GetErrors(exception)
            };

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                BaseException applicationException => applicationException.Title,
                _ => "Server Error"
            };

        private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.ErrorsDictionary;
            }

            return errors;
        }
    }
}
