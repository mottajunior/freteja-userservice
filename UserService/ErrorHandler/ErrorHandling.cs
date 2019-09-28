using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace UserService.ErrorHandler
{
    public class ErrorHandling : ActionFilterAttribute
    {
        private readonly RequestDelegate _next;
        private static ILogger _logger;

        public ErrorHandling(RequestDelegate next, ILogger<ErrorHandling> logger)
        {
            _next = next;
            _logger = logger;
        }

        public ErrorHandling() { }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);
            List<Error> arrError = new List<Error>();

            arrError.Add(new Error { Mensagem = exception.Message, InnerException = exception.InnerException?.ToString() });

            if (context.Response.StatusCode == 500)
                _logger.LogCritical(exception, "Erro interno no servidor");
            else
                _logger.LogInformation("Excessao Tratada StatusCode: {0}", context.Response.StatusCode);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(arrError));
        }

        private static int GetStatusCode(Exception ex)
        {
            var type = ex.GetType();
            switch (type.Name)
            {
                case "NotFoundException":
                    return (int)HttpStatusCode.NotFound;


                case "BadRequestException":
                    return (int)HttpStatusCode.BadRequest;

                case "ConflictException":
                    return (int)HttpStatusCode.Conflict;

                default:
                    return (int)HttpStatusCode.InternalServerError;
            }
        }
    }

    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandling>();
        }
    }
}
